using System.ComponentModel.DataAnnotations;

namespace RodeoDrive.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Будь ласка введіть своє ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Будь ласка введіть вулицю")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Будь ласка введіть назву міста")]
        public string City { get; set; }
        [Required(ErrorMessage = "Будь ласка введіть назву регіону")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Будь ласка введіть назву країни")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
