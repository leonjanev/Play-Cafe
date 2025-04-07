using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayCafe.ViewModels.Cafe
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key for SubCategory
        public int SubCategoryId { get; set; }

        // Navigation property
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
    }
} 