namespace ProductControl.Interfaces.Services
{
    public interface IElectronicsProduct : IProduct
    {
        DateTime GetWarrantyPeriod(int warranty);
    }
}
