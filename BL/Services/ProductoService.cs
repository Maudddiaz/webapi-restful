using Microsoft.AspNetCore.Http.HttpResults;
using WebApi_Gestion_en_3_capas.BL.DTOs;
using WebApi_Gestion_en_3_capas.DAL.Models;
using WebApi_Gestion_en_3_capas.DAL.Repositories;

namespace WebApi_Gestion_en_3_capas.BL.Services
{
    public class ProductoService: IProductoService
    {
        private readonly IProductoRepository _repositorio;

        public  ProductoService(IProductoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        //obteneer todos los productos debo convertir a dto

        public List<ProductoDto> ObtenerTodos()
        {//el error tipico que tenia aca y no me di cuenta es que  yo defini list<ProductoDto> y le queria pasar una lista de Producto , Producto != ProductoDto
            List<Producto> _productos = _repositorio.ObtenerTodos();
            return _productos.Select(p => new ProductoDto
                {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Categoria = p.Categoria

            }).ToList();
        }


        public ProductoDto ObtenerPorId(int Id) 
        {
            Producto _producto = _repositorio.ObtenerPorId(Id);
            if (_producto == null)
            {
                return null;
            }
            ProductoDto p = new ProductoDto
            {
                Id = _producto.Id,
                Nombre = _producto.Nombre,
                Precio = _producto.Precio,
                Categoria = _producto.Categoria
            };

            return p;
        }

        public List <ProductoDto> BuscarPorCategoria(string Categoria)
        {
            List<Producto> _productos = _repositorio.BuscarPorCategoria(Categoria);
            if (_productos == null) 
            { 
                return null; 
            }
            return _productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Categoria = p.Categoria
            }).ToList();
        }


        public ProductoDto AgregarProducto(CreateProductoDto p)
        {
            Producto _p = new Producto
            {
                Nombre= p.Nombre,
                Precio = p.Precio,
                Categoria = p.Categoria
            };
            _repositorio.AgregarProducto(_p);
            return new ProductoDto
            {
                Nombre = _p.Nombre,
                Precio = _p.Precio,
                Categoria = _p.Categoria
            };
        }

        public bool ActualizarProducto(CreateProductoDto act,int Id)
        {
            Producto actp = new Producto
            {
                Categoria = act.Categoria,
                Nombre = act.Nombre,
                Precio = act.Precio
            };

            return _repositorio.ActualizarProducto(actp,Id);
        }

        public bool EliminarProducto(int Id)
        {
            return _repositorio.EliminarProducto(Id);
        }

    }
}
