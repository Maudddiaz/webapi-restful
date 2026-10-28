using System;
using System.Collections.Generic;
using System.Text;
using WebApi_Gestion_en_3_capas.DAL.Models;

namespace WebApi_Gestion_en_3_capas.DAL.Repositories
{
    public interface IProductoRepository
    {
        void AgregarProducto(Producto P);
        List<Producto> ObtenerTodos();
        Producto ObtenerPorId(int Id);
        List<Producto> BuscarPorCategoria(string Categoria);

        bool ActualizarProducto(Producto p,int Id);

        bool EliminarProducto(int Id);
    }
}
