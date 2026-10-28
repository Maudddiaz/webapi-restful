using System;
using System.Collections.Generic;
using System.Text;
using WebApi_Gestion_en_3_capas.DAL.Models;
namespace WebApi_Gestion_en_3_capas.DAL.Repositories
{
    public class RepositorioProductos : IProductoRepository
    {
        //la palabra readonly indica que la variable productos no puede ser reasignada después de su inicialización, lo que significa que no se puede cambiar la referencia de la lista a otra lista diferente. Sin embargo, los elementos dentro de la lista aún pueden ser modificados, agregados o eliminados.
        private static readonly List<Producto> productos = new List<Producto>()
        {
            new Producto { Id = 1, Nombre = "harina", Precio = 1500, Categoria = "Comida", Activo = true },
            new Producto { Id = 2, Nombre = "azucar", Precio = 2000, Categoria = "Comida", Activo = true },
            new Producto { Id = 3, Nombre = "Rueda", Precio = 1750, Categoria = "Transporte", Activo = true }
        };
        public void AgregarProducto(Producto p) 
        {
            //MEDIO MALO LA VERDAD NOSE SI SERIA MEJOR UTILIZAR UNA VARIABLE ESTATICA PERO COMO ESTA TODO EN RAM NOSE
            p.Id = productos.Max(x => x.Id) + 1;
            productos.Add(p);
        }

        public List<Producto> ObtenerTodos() => productos;

        public Producto ObtenerPorId(int id) 
        {
            Producto prod = productos.FirstOrDefault(p => p.Id == id);
            return prod;
        }

        public List<Producto> BuscarPorCategoria(string Categoria) 
        {
            List<Producto> conjuntoProductos = productos.Where(p => p.Categoria == Categoria).ToList();
            return conjuntoProductos;
        }

        public bool ActualizarProducto(Producto modprod,int Id)
        {
            var pactualizar = productos.FirstOrDefault(p => p.Id == Id );
            if(pactualizar == null)
            {
                return false;
            }
            pactualizar.Nombre = modprod.Nombre;
            pactualizar.Precio = modprod.Precio;
            pactualizar.Categoria = modprod.Categoria;
            return true;
        }

        public bool EliminarProducto(int Id)
        {
            var p = productos.FirstOrDefault(p => p.Id == Id);
            if (p == null)
            {
                return false;
            }
            productos.Remove(p);
            return true;
        }

    }
}
