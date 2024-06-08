using System.ComponentModel.DataAnnotations;

namespace PFuzzyArtShop.Models
{
    public class Merch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the merch.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the price of the merch.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public string? Size { get; set; } // Make the Size property nullable
    }
}