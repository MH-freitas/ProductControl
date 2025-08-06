using Microsoft.AspNetCore.Mvc;
using ProductControl.Data;
using ProductControl.Enums;
using ProductControl.Models;

namespace ProductControl.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var product = _context.Product.ToList();    
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetbyName(string name)
        {
            var product = _context.Product.FirstOrDefault(p => p.Name == name);
            if (product == default)
            {
                throw new Exception("Produto não encontrado");
            }

            return Ok(product);
        }

        [HttpGet("category/{category}")]
        public IActionResult GetbyCategory(EProduct category)
        {
            var listCategory = _context.Product.Where(p => p.Category == category).ToList();
            if (!listCategory.Any())
            {
                throw new Exception("Categoria não encontrada");
            }

            return Ok(listCategory);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Product product)
        {
            var exist = _context.Product.FirstOrDefault(p => p.Id == id);
            if (exist == null) return NotFound();

            exist.Name = product.Name;
            exist.Quantity = product.Quantity;
            exist.Price = product.Price;
            exist.Category = product.Category;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            _context.Product.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}