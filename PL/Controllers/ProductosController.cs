using Microsoft.AspNetCore.Mvc;
using WebApi_Gestion_en_3_capas.BL.Services;
using WebApi_Gestion_en_3_capas.BL.DTOs;
namespace WebApi_Gestion_en_3_capas.PL.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        //obtener todos los productos
        [HttpGet]
        public ActionResult<List<ProductoDto>> GetProductos()
        {
            var _products = _service.ObtenerTodos();
            return Ok(_productos);
        }

        //Obtener un producto
        [HttpGet("{id}")]
        public ActionResult<ProductoDto> GetProducto(int Id)
        {
            var _product = _service.ObtenerPorId(Id);
            return Ok(_product);
        }


        //Buscar Por categoria
        [HttpGet]
        public ActionResult<List<ProductoDto>> GetPxC([FromQuery] string? Categoria)
        {
            if (string.IsNullOrWhiteSpace(Categoria))
            {
                return BadRequest(new { mensaje = "Debe proporcionar una categoria valida" });
            }
            var _products = _service.BuscarPorCategoria(Categoria);
            if (_products == null)
                return NotFound();

            return Ok(_products);
        }

        //Crear un producto
        [HttpPost] // segun tengo entendido IActionResult no devuelve nada solo codigos de estado, pero yo necesito saber cual fue el producto que cree desde el body
        public ActionResult CreteProducto([FromBody] CreateProductoDto prod)
        {
            var creacion = _service.agregarProducto(prod);
            return Ok(creacion);
        }

        //Actualizar un producto
        [HttpPut("{id}")]
        public IActionResult UpdateProducto([FromBody] CreateProductoDto prod,int id)
        {
            var actualizacion = _service.ActualizarProducto(prod, id);
            if (actualizacion == null)
            {
                return NotFound();
            }
            return Ok();
        }

        []

    }
}
