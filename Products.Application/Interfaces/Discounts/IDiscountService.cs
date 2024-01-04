namespace Products.Application.Interfaces.Discounts;

public interface IDiscountService
{
    Task<decimal> GetDiscount(int productId);
}
