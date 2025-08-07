using ProductControl.Enums;

namespace ProductControl.Models
{
    public class Product
    {
        private Guid _id { get;} = Guid.NewGuid();

        public string? _name{ get; private set; }

        public int _quantity { get; private set; }

        public decimal _price { get; private set; }
        
        public EProduct _category { get; private set; }

        public Guid Id
        {
            get {return _id;}
        }

        public string? Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nome não pode ser vazio ou nulo.");
                }
                _name = value;
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if(value >= 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new ArgumentException("Quantidade não pode ser negativa.");
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentException("Preço não pode ser negativo.");
                }
            }
        }

        public EProduct Category
        {
            get { return _category; }
            set
            {
                if (Enum.IsDefined(typeof(EProduct), value))
                {
                    _category = value;
                }
                else
                {
                    throw new ArgumentException("Categoria inválida.");
                }
            }
        }

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
