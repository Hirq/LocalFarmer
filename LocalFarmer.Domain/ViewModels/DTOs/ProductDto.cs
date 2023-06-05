using System.ComponentModel.DataAnnotations;

namespace LocalFarmer.Domain.ViewModels.DTOs
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountAll { get; set; }
        public string CountMinOne { get; set; }
        public string PrizeOne { get; set; }
    }
}
