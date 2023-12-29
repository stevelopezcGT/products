using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public int StatusId { get; set; }

        [Column(TypeName = "numeric(10,2)")]
        public decimal Stock { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "numeric(18,2)")]
        public decimal Price { get; set; } = 0;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
