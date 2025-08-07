using ProductControl.Enums;
using ProductControl.Interfaces.Services;

namespace ProductControl.Services
{
    public class ClothingServices : IClothingProduct
    {
        public EProduct ProductCategory => EProduct.Clothing;

        public decimal ProductDiscount(decimal discount, decimal productPrice)
        {
            if (discount < 0 || discount > 1)
            {
                throw new ArgumentOutOfRangeException("Discount must be between 0 and 1.");
            }
            decimal basePrice = productPrice;
            return basePrice * (1 - discount);
        }

        public string ClothingSize(EClothingSize size)
        {
            if (string.IsNullOrWhiteSpace(size))
            {
                throw new ArgumentException("Tamanho não pode ser null ou vazio");
            }

            switch (size)
            {
                case EClothingSize.PP:
                    {
                        return "Tamanho PP";
                    }

                case EClothingSize.P:
                    {
                        return "Tamanho P";

                    }

                case EClothingSize.M:
                    {
                        return "Tamanho M";
                    }

                case EClothingSize.G:
                    {
                        return "Tamanho G";
                    }

                case EClothingSize.GG:
                    {
                        return "Tamanho GG";
                    }

                default:
                    throw new ArgumentException("Tamanho inválido");
            }
        }
    }
}
