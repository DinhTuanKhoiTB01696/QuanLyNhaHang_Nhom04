using System.ComponentModel.DataAnnotations;

namespace Assignment_NET201.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal? PriceOverride { get; set; }

        public ICollection<InventoryTransaction> Transactions { get; set; }
    }
}
