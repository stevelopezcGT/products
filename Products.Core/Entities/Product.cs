namespace Products.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public decimal Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
