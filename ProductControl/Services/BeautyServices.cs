using ProductControl.Enums;
using ProductControl.Models;
using ProductControl.Data;
using ProductControl.Interfaces.Services;

namespace ProductControl.Services
{
    public class BeautyServices : IBeautyProduct
    {
        public EProduct ProductCategory => EProduct.Beauty;

        public decimal ProductDiscount(decimal discount, decimal productPrice)
        {
            if (discount < 0 || discount > 1)
            {
                throw new ArgumentOutOfRangeException("Discount must be between 0 and 1.");
            }
            decimal basePrice = productPrice;
            return basePrice * (1 - discount);
        }

        public string Ishypoallegenic(bool hypoallegenic)
        {
            if (hypoallegenic)
            {
                return "Este produto é hipoalergênico.";
            }
            else
            {
                return "Este produto não é hipoalergênico.";
            }
        }
    }
}
