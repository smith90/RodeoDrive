using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RodeoDrive.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Будь ласка введіть назву продукту")]
        [Display(Name="Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Будь ласка введіть опис продукту")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Будь ласка введіть додатню ціну")]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Будь ласка визначте категорію")]
        [Display(Name = "Категорія")]
        public string Category { get; set; }
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
