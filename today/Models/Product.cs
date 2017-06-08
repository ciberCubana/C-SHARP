using System.ComponentModel.DataAnnotations;

namespace today.Models
{
    public class Product
    {
        [Display(Name="Please change the name")]
        public string Name { get; set; }
        public string Category { get;set; }

        [Display(Name="Change the price of this DVD")]
        public decimal Price { get;set; }
    }
}