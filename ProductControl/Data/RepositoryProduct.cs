using ProductControl.Models;
using System.Runtime.InteropServices;

namespace ProductControl.Data
{
    public class RepositoryProduct
    {
        List<Product> products = new List<Product>
            {
                new Product { Name = "Blue Pen", Quantity = 100, Price = 1.50m },
                new Product { Name = "Notebook", Quantity = 50, Price = 12.90m },
                new Product { Name = "Pencil HB", Quantity = 200, Price = 0.99m },
                new Product { Name = "School Backpack", Quantity = 30, Price = 89.90m },
                new Product { Name = "White Eraser", Quantity = 150, Price = 0.80m },
                new Product { Name = "Ruler 30cm", Quantity = 75, Price = 2.50m },
                new Product { Name = "Dual Sharpener", Quantity = 60, Price = 3.40m },
                new Product { Name = "Agenda 2025", Quantity = 20, Price = 22.00m },
                new Product { Name = "Yellow Highlighter", Quantity = 90, Price = 4.20m },
                new Product { Name = "Basic Pencil Case", Quantity = 40, Price = 8.75m }
           };


        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetbyId(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }

            return product;
        }

        public Product GetbyName(string name)
        {
            var product = products.FirstOrDefault(p => p.Name == name);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }
            return product;
        }

        public Product Add(string name, int quatity, decimal price)
        {
           if(products.Any(p => p.Name == name))
            {
                throw new Exception("Produto não existe");
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Quantity = quatity,
                Price = price
            };

            products.Add(product);

            return product;
        }

        public Product Update(string name, int quatity, decimal price)
        {
            var product = products.FirstOrDefault(p => p.Name == name);
            if (product == default)
            {
                throw new Exception("Produto nâo encontrado");
            }

            product.Name = name;
            product.Quantity = quatity;
            product.Price = price;

            return product;
        }

        public void Delete(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }

            products.Remove(product);
        }
    }
}
