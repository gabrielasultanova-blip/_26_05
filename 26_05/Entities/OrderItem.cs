using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_05.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; } 

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
