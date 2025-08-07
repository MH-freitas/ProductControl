using ProductControl.Enums;
using ProductControl.Interfaces.Services;

namespace ProductControl.Services
{
    public class FoodServices : IFoodProduct
    {
        public EProduct ProductCategory => EProduct.Food;

        public decimal ProductDiscount(decimal discount, decimal productPrice)
        {
            if (discount < 0 || discount > 1)
            {
                throw new ArgumentOutOfRangeException("Discount must be between 0 and 1.");
            }
            decimal basePrice = productPrice;
            return basePrice * (1 - discount);
        }

        public DateTime Validity(DateTime validaty)
        {
            if (validaty <= DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("A validade do produto deve ser uma data futura.");
            }

            return validaty;
        }
    }
}
