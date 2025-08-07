namespace ProductControl.Interfaces.Services
{
    public interface IFoodProduct : IProduct
    {
        DateTime Validity(DateTime validaty);
    }
}
