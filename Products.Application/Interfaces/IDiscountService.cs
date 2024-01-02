namespace Products.Application.Interfaces;

public interface IDiscountService
{
    Task<decimal> GetDiscount(int productId);
}
