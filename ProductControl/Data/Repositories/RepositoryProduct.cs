using ProductControl.Enums;
using ProductControl.Models;
using System.Runtime.InteropServices;
using ProductControl.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProductControl.Data.Repositories
{
    public class RepositoryProduct: IProductRepositorie
    {
        private readonly AppDbContext _context;

        public RepositoryProduct(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public Product GetbyId(Guid id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }

            return product;
        }

        public Product GetbyName(string name)
        {
            var product = _context.Product.FirstOrDefault(p => p.Name == name);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }

            return product;
        }

        public List<Product> GetbyCategory(EProduct category)
        {
            var listCategory = _context.Product.Where(p => p.Category == category).ToList();
            if (!listCategory.Any())
            {
                throw new Exception("Categoria não encontrada");
            }

            return listCategory;
        }

        public Product Add(string name, int quatity, decimal price, EProduct category)
        {
            if (_context.Product.Any(p => p.Name == name))
            {
                throw new Exception("Produto não existe");
            }

            var product = new Product
            {
                Name = name,
                Quantity = quatity,
                Price = price,
                Category = category
            };

            _context.Add(product);

            _context.SaveChanges();
            return product;
        }

        public Product Update(Guid id, string name, int quantity, decimal price, EProduct category)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product == default)
            {
                throw new Exception("Produto nâo encontrado");
            }

            product.Name = name;
            product.Quantity = quantity;
            product.Price = price;
            product.Category = category;

            _context.SaveChanges();
            return product;
        }

        public void Delete(Guid id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }

            _context.SaveChanges();
            _context.Remove(product);
            Console.WriteLine($"Produto {product.Name} removido com sucesso.");

        }
    }
}
