using RodeoDrive.Domain.Entities;

namespace RodeoDrive.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}