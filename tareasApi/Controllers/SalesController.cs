using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using tareasApi.models;
using tareasApi.Models;

namespace tareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly Bdtareas903Context _context;

        public SalesController(Bdtareas903Context context)
        {
            _context = context;
        }

        // POST /api/addSale - Registrar una compra con fecha de compra automática
        [HttpPost]
        [Route("/api/addSale")]
        public async Task<IActionResult> AddSale([FromBody] Compra saleRequest)
        {
            if (saleRequest == null || saleRequest.ProductoId <= 0)
                return BadRequest("Datos de compra no válidos.");

            // Establecer la fecha de compra automáticamente con la fecha y hora actual del servidor
            saleRequest.FechaCompra = DateTime.UtcNow;

            // Guardar la compra en la base de datos
            await _context.Compras.AddAsync(saleRequest);
            var result = await _context.SaveChangesAsync();

            // Retornar true si se guardó correctamente, de lo contrario false
            return Ok(result > 0);
        }

            // GET /api/sales - Obtener todas las compras con detalles del producto sin propiedad de navegación
            [HttpGet]
        [Route("/api/sales")]
        public async Task<IActionResult> GetAllSales()
        {
            // Obtener todas las compras de la base de datos
            var sales = await _context.Compras.ToListAsync();

            // Construir la lista de resultados incluyendo los detalles del producto
            var salesResult = new List<object>();

            foreach (var sale in sales)
            {
                // Obtener detalles del producto según el ProductoId de cada compra
                var productDetails = await _context.Products
                    .Where(p => p.Id == sale.ProductoId)
                    .Select(p => new
                    {
                        p.Title,
                        p.Description,
                        p.Price,
                        p.Thumbnail
                    })
                    .FirstOrDefaultAsync();

                // Crear un objeto que combine la compra y los detalles del producto
                salesResult.Add(new
                {
                    sale.CompraId,
                    sale.FechaCompra,
                    ProductId = sale.ProductoId,
                    ProductDetails = productDetails
                });
            }

            return Ok(salesResult);
        }
    }
}
