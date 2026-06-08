using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _26_05.Enums;

namespace _26_05.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; } 

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public override string ToString()
        {
            return $"Поръчка: {Id}. | Дата: {OrderDate.ToString("dd.MM.yyyy HH:mm")} | Статус: {Status}";
        }
    }
}
