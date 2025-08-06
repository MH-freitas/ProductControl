using ProductControl.Models;
using ProductControl.Enums;

namespace ProductControl.Interfaces
{
    public interface IProduct
    {
        EProduct ProductCategory { get; }

        decimal ProductDiscount(decimal discount,  decimal productPrice);
    }
}
