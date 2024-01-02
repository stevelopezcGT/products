using System.Text.Json.Serialization;

namespace Products.Domain.Model;

public class DiscountModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("discount")]
    public decimal Discount {  get; set; }
}
