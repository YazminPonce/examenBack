using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using tareasApi.models;
using tareasApi.Models;

namespace tareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Bdtareas903Context _context;

        public ProductsController(Bdtareas903Context context)
        {
            _context = context;
        }

        // GET api/products?q=:query - Búsqueda de productos
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("Debe proporcionar un término de búsqueda.");

            var products = await _context.Products
                .Where(p => p.Title.Contains(q) || p.Description.Contains(q) || p.Category.Contains(q))
                .ToListAsync();

            return Ok(products);
        }

        // GET api/products/:id - Obtener detalles de un producto por ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound("Producto no encontrado.");

            return Ok(product);
        }

       
    }
}
