using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InterViewWebApp.Model
{
    public class Unit
    {
        [Key]
        public int unitNo { get; set; }

        [Required]
        public string unitName { get; set; }
    }
}
