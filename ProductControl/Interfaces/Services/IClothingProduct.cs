using ProductControl.Enums;

namespace ProductControl.Interfaces.Services
{
    public interface IClothingProduct : IProduct
    {
        string ClothingSize(EClothingSize size);
    }
}
