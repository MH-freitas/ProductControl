using ProductControl.Models;
using ProductControl.Enums;

namespace ProductControl.Interfaces.Repositories
{
    public interface IProductRepositorie
    {
        List<Product> GetAll();

        Product GetbyId(Guid id);

        Product GetbyName(string name);

        List<Product> GetbyCategory(EProduct category);

        Product Add(string name, int quatity, decimal price, EProduct category);

        Product Update(Guid id, string name, int quantity, decimal price , EProduct category);
  
        void Delete(Guid id);
    }
}
