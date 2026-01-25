using Assignment_NET201.Data;
using Assignment_NET201.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_NET201.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Dashboard
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.Products.Count();
            ViewBag.OrderCount = _context.Orders.Count();
            ViewBag.UserCount = _context.Users.Count();
            ViewBag.Revenue = _context.Orders.Where(o => o.Status == "Delivered").Sum(o => o.TotalAmount);
            return View();
        }

        // --- PRODUCTS ---
        public async Task<IActionResult> Products()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile? imageFile)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    product.ImageUrl = "/images/products/" + uniqueFileName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // Edit Product GET
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // Edit Product POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, Product product, IFormFile? imageFile)
        {
            if (id != product.Id) return NotFound();

            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null)
                    {
                        // Delete old image if exists and not external URL
                        if (!string.IsNullOrEmpty(product.ImageUrl) && product.ImageUrl.StartsWith("/images/products/"))
                        {
                            var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/'));
                            if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                        }

                        // Save new image
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

                        if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        product.ImageUrl = "/images/products/" + uniqueFileName;
                    }
                    else
                    {
                        // Keep existing image if no new file is uploaded
                        // We need to detach the entity to avoid tracking conflict if we fetched it similarly
                        // But here 'product' comes from form. We need to preserve ImageUrl if it wasn't in form (hidden field recommended)
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.Id == product.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Products));
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // Delete Product POST
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                // Optional: Delete image file
                if (!string.IsNullOrEmpty(product.ImageUrl) && product.ImageUrl.StartsWith("/images/products/"))
                {
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Products));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleProductStatus(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsActive = !product.IsActive;
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Products));
        }

        // --- ORDERS ---
        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders.Include(o => o.User).OrderByDescending(o => o.OrderDate).ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> OrderDetail(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // --- USERS ---
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await _userManager.GetRolesAsync(user);
            }
            ViewBag.UserRoles = userRoles;
            return View(users);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();

            ViewBag.Roles = new SelectList(allRoles, "Name", "Name", userRoles.FirstOrDefault());
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, AppUser appUser, string selectedRole)
        {
            if (id != appUser.Id) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.FullName = appUser.FullName;
            user.Address = appUser.Address;
            user.Email = appUser.Email;
            user.PhoneNumber = appUser.PhoneNumber;
            // UserName is usually same as Email in default identity, but let's keep it simple or sync them
            user.UserName = appUser.Email;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var resultRemove = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (resultRemove.Succeeded)
                {
                    if (!string.IsNullOrEmpty(selectedRole))
                    {
                        await _userManager.AddToRoleAsync(user, selectedRole);
                    }
                }
                return RedirectToAction(nameof(Users));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            var allRoles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            ViewBag.Roles = new SelectList(allRoles, "Name", "Name", userRoles.FirstOrDefault());
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Users));
        }

        // --- INVENTORY ---
        public async Task<IActionResult> Inventory()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new
                {
                    Product = p,
                    TotalStock = _context.ProductVariants.Where(pv => pv.ProductId == p.Id).Sum(pv => pv.Quantity)
                }).ToListAsync();

            ViewBag.InventoryData = products;
            return View(await _context.Products.Include(p => p.Category).ToListAsync());
        }

        public async Task<IActionResult> ProductVariants(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            var variants = await _context.ProductVariants
                .Where(pv => pv.ProductId == productId)
                .ToListAsync();

            ViewBag.Product = product;
            return View(variants);
        }

        public IActionResult CreateVariant(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVariant(ProductVariant variant)
        {
            if (ModelState.IsValid)
            {
                _context.ProductVariants.Add(variant);
                await _context.SaveChangesAsync();

                // Log initial stock as transaction if quantity > 0
                if (variant.Quantity > 0)
                {
                    var transaction = new InventoryTransaction
                    {
                        ProductVariantId = variant.Id,
                        Type = "Import",
                        Quantity = variant.Quantity,
                        Note = "Initial stock",
                        CreatedBy = User.Identity?.Name
                    };
                    _context.InventoryTransactions.Add(transaction);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(ProductVariants), new { productId = variant.ProductId });
            }
            return View(variant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportStock(int variantId, int quantity, string? note)
        {
            var variant = await _context.ProductVariants.FindAsync(variantId);
            if (variant == null) return NotFound();

            variant.Quantity += quantity;
            _context.Update(variant);

            var transaction = new InventoryTransaction
            {
                ProductVariantId = variantId,
                Type = "Import",
                Quantity = quantity,
                Note = note,
                CreatedBy = User.Identity?.Name
            };
            _context.InventoryTransactions.Add(transaction);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProductVariants), new { productId = variant.ProductId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExportStock(int variantId, int quantity, string? note)
        {
            var variant = await _context.ProductVariants.FindAsync(variantId);
            if (variant == null) return NotFound();

            if (variant.Quantity < quantity)
            {
                TempData["Error"] = "Insufficient stock.";
                return RedirectToAction(nameof(ProductVariants), new { productId = variant.ProductId });
            }

            variant.Quantity -= quantity;
            _context.Update(variant);

            var transaction = new InventoryTransaction
            {
                ProductVariantId = variantId,
                Type = "Export",
                Quantity = quantity,
                Note = note,
                CreatedBy = User.Identity?.Name
            };
            _context.InventoryTransactions.Add(transaction);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProductVariants), new { productId = variant.ProductId });
        }

        public async Task<IActionResult> InventoryHistory(int? variantId)
        {
            var query = _context.InventoryTransactions
                .Include(t => t.ProductVariant)
                    .ThenInclude(pv => pv.Product)
                .AsQueryable();

            if (variantId.HasValue)
            {
                query = query.Where(t => t.ProductVariantId == variantId.Value);
            }

            var history = await query.OrderByDescending(t => t.CreatedAt).ToListAsync();
            return View(history);
        }
    }
}
