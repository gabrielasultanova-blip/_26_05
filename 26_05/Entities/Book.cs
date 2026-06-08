using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_05.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        [Range(0.01, 1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Pages { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Quantity { get; set; }

        [Required]
        public bool InStock { get; set; } = true;

        [Required]
        public DateOnly PublishedOn { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public override string ToString()
        {
            if (this.Author != null && !string.IsNullOrEmpty(this.Author.FirstName) && this.Publisher != null && !string.IsNullOrEmpty(this.Publisher.Name))
            {
                return $"{this.Title} - {this.Author.FirstName} {this.Author.LastName} | {this.Price} euro";
            }
            return $"{this.Title} | {this.Price} euro";
        }
    }
}
