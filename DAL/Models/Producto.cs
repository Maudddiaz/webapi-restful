using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Gestion_en_3_capas.DAL.Models
{ 

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Categoria { get; set; }
        public bool Activo { get; set; }
    }
}