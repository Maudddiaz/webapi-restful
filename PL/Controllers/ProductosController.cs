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

        //obtener todos los productos,y por categoria mediante querys
        [HttpGet]
        public ActionResult<List<ProductoDto>> GetProductos([FromQuery] string? Categoria)
        {
            if (!string.IsNullOrWhiteSpace(Categoria))
            {
                var _products = _service.BuscarPorCategoria(Categoria);
                if (_products.Count == 0)
                    return NotFound();
                return Ok(_products);
            }
            ;
            //pasa por el primer if, si esta vacio el string, entonces hace la busqueda de todos :D
            var _productos = _service.ObtenerTodos();
            return Ok(_productos);
        }

        //Obtener un producto
        [HttpGet("{id}")]
        public ActionResult<ProductoDto> GetProducto(int Id)
        {
            var _product = _service.ObtenerPorId(Id);
            return Ok(_product);
        }


 

        //Crear un producto
        [HttpPost] // segun tengo entendido IActionResult no devuelve nada solo codigos de estado, pero yo necesito saber cual fue el producto que cree desde el body
        public ActionResult CreteProducto([FromBody] CreateProductoDto prod)
        {
            var creacion = _service.AgregarProducto(prod);
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

        //Borrar un Producto 
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            _service.EliminarProducto(id);
            return Ok();
        }

    }
}
