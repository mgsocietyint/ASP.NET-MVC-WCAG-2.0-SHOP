using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disabled.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Pole imię jest wymagane.")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pole adres jest wymagane.")]
        [StringLength(150)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Pole kod pocztowy jest wymagane.")]
        [StringLength(20)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Pole miasto jest wymagane.")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Pole numer telefonu jest wymagane.")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        [Required(ErrorMessage = "Pole e-mail jest wymagane.")]
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
    public enum OrderState
    {
        [Display(Name = "Nowe")]
        New,
        [Display(Name = "Przetwarzane")]
        Processed,
        [Display(Name = "Wysłane")]
        Shipped
    }
}