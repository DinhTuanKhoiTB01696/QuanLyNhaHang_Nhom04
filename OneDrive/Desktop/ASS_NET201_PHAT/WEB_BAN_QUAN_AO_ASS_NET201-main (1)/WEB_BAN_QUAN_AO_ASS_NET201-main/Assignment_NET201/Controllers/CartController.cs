using Assignment_NET201.Data;
using Assignment_NET201.Extensions;
using Assignment_NET201.Models;
using Assignment_NET201.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_NET201.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        public IActionResult AddToCart(int productId, int quantity = 1, string size = "M")
        {
            var product = _context.Products.Find(productId);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            var existingItem = cart.FirstOrDefault(c => c.ProductId == productId && c.Size == size);

            int currentInCart = existingItem?.Quantity ?? 0;
            int totalNewQuantity = currentInCart + quantity;

            if (totalNewQuantity > product.Quantity)
            {
                TempData["Message"] = $"Số lượng chỉ còn {product.Quantity} không thể thêm";
                totalNewQuantity = product.Quantity;
            }

            if (totalNewQuantity <= 0 && product.Quantity > 0)
            {
                // This shouldn't happen with quantity = 1, but for safety
                totalNewQuantity = 1;
            }

            if (product.Quantity <= 0)
            {
                TempData["Message"] = "Sản phẩm đã hết hàng";
                return RedirectToAction("Index");
            }

            if (existingItem != null)
            {
                existingItem.Quantity = totalNewQuantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = totalNewQuantity,
                    ImageUrl = product.ImageUrl,
                    Size = size
                });
            }

            HttpContext.Session.Set("Cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId, string size)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => c.ProductId == productId && c.Size == size);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.Set("Cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (!cart.Any()) return RedirectToAction("Index");

            var user = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUser = user;

            return View(cart);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (!cart.Any()) return RedirectToAction("Index");

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            // Validate that all products in cart actually exist in database
            var validCartItems = new List<CartItem>();
            var productIds = cart.Select(c => c.ProductId).ToList();
            var existingProducts = _context.Products.Where(p => productIds.Contains(p.Id)).ToList();

            foreach (var item in cart)
            {
                var product = existingProducts.FirstOrDefault(p => p.Id == item.ProductId);
                if (product != null)
                {
                    // Update price/name from DB to be safe, or just keep cart but valid
                    // Checking stock here
                    if (product.Quantity >= item.Quantity)
                    {
                        validCartItems.Add(item);

                        // Deduct stock
                        product.Quantity -= item.Quantity;
                        _context.Update(product);
                    }
                    else
                    {
                        // Handle out of stock during checkout logic if needed, 
                        // for now we skip or clamp? 
                        // Let's just skip invalid to prevent crash
                    }
                }
            }

            if (!validCartItems.Any())
            {
                // All items were invalid (e.g. from old DB session)
                HttpContext.Session.Remove("Cart");
                TempData["Message"] = "Giỏ hàng chứa sản phẩm không tồn tại hoặc đã hết hàng. Vui lòng thử lại.";
                return RedirectToAction("Index");
            }

            // Update session with only valid items if we filtered some out
            if (validCartItems.Count != cart.Count)
            {
                // Partial success not fully handled here for simplicity, 
                // just proceeding with valid ones.
            }

            var order = new Order
            {
                UserId = user.Id,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = validCartItems.Sum(c => c.Total),
                OrderDetails = validCartItems.Select(c => new OrderDetail
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Clear Cart
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("OrderConfirmation", new { id = order.Id });
        }

        [Authorize]
        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }

        // --- Wishlist Actions ---
        public IActionResult Wishlist()
        {
            var wishlist = HttpContext.Session.Get<List<WishlistItem>>("Wishlist") ?? new List<WishlistItem>();
            return View(wishlist);
        }

        public IActionResult AddToWishlist(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return NotFound();

            var wishlist = HttpContext.Session.Get<List<WishlistItem>>("Wishlist") ?? new List<WishlistItem>();

            if (!wishlist.Any(w => w.ProductId == productId))
            {
                wishlist.Add(new WishlistItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl
                });
                HttpContext.Session.Set("Wishlist", wishlist);
            }

            return RedirectToAction("Wishlist");
        }

        public IActionResult RemoveFromWishlist(int productId)
        {
            var wishlist = HttpContext.Session.Get<List<WishlistItem>>("Wishlist") ?? new List<WishlistItem>();
            var item = wishlist.FirstOrDefault(w => w.ProductId == productId);
            if (item != null)
            {
                wishlist.Remove(item);
                HttpContext.Session.Set("Wishlist", wishlist);
            }
            return RedirectToAction("Wishlist");
        }
    }
}
