using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterViewWebApp.Model
{
    public class InvoiceDetails
    {
        [Key]
        public int lineNo { get; set; }

        [Required]
        public string productName { get; set; }

        [ForeignKey("Unit")]
        public int? UnitNo { get; set; }

        public Unit? Unit { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public decimal total { get; set; }

        public DateTime expiryDate { get; set; } = DateTime.Now;

    }
}
