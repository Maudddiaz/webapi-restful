using WebApi_Gestion_en_3_capas.BL.DTOs;
using WebApi_Gestion_en_3_capas.DAL.Models;
namespace WebApi_Gestion_en_3_capas.BL.Services
{
    public interface IProductoService
    {
        List<ProductoDto> ObtenerTodos();

        ProductoDto AgregarProducto(CreateProductoDto p);
        ProductoDto? ObtenerPorId(int Id);
        List<ProductoDto> BuscarPorCategoria(string Categoria);

        bool ActualizarProducto(CreateProductoDto p,int i);

        bool EliminarProducto(int Id);
    }
}
