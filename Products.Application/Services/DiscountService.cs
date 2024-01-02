
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Products.Application.Interfaces;
using Products.Domain.Model;

namespace Products.Application.Services;

public class DiscountService : IDiscountService
{
    private readonly IConfiguration configuration;
    private readonly HttpClient httpClient;

    public DiscountService(IConfiguration _configuration)
    {
        configuration = _configuration;
        httpClient = new HttpClient();
    }

    public async Task<decimal> GetDiscount(int productId)
    {
        var urlApi = configuration.GetSection("AppSettings").GetChildren().FirstOrDefault(d => d.Key == "API_DISCOUNT_URL")?.Value ?? string.Empty;
        decimal discount = 0;
        if (!string.IsNullOrEmpty(urlApi))
        {
            httpClient.BaseAddress = new Uri(urlApi);
            var result = await httpClient.GetAsync($"/{productId}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();

                var discountResponse = JsonConvert.DeserializeObject<DiscountModel>(response);
                if (discountResponse != null)
                {
                    return discountResponse.Discount;
                }
            }
        }

        return discount;
    }
}

