using ProductControl.Enums;

namespace ProductControl.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name{ get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        
        public EProduct Category { get; set; }

        public Product() { }

        public Product(Guid id, string? name, int quantity, decimal price, EProduct category)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Name}, Quantidade: {Quantity}, Preço: R${Price:F2},  Categoria: {Category}";
        }
    }
}
