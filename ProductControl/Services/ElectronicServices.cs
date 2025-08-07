using ProductControl.Enums;
using ProductControl.Interfaces.Services;

namespace ProductControl.Services
{
    public class ElectronicServices : IElectronicsProduct
    {
        public EProduct ProductCategory => EProduct.Electronics;

        public decimal ProductDiscount(decimal discount, decimal productPrice)
        {
            if (discount < 0 || discount > 1)
            {
                throw new ArgumentOutOfRangeException("Discount must be between 0 and 1.");
            }
            decimal basePrice = productPrice;
            return basePrice * (1 - discount);
        }

        public DateTime GetWarrantyPeriod(int warranty)
        {
            return DateTime.Now.AddYears(warranty);
        }
    }
}
