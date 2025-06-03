using System;
using System.ComponentModel.DataAnnotations;

namespace OOP_CourseWork.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public TypeWear TypeWear { get; set; }

        public byte[] Image { get; set; }
    }
} 