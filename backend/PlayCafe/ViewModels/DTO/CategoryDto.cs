using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayCafe.ViewModels.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

    }
} 