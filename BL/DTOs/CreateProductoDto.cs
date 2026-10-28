using System.ComponentModel.DataAnnotations;

namespace WebApi_Gestion_en_3_capas.BL.DTOs
{
    public class CreateProductoDto
    {
        [Required]
        [StringLength(100,MinimumLength=3,ErrorMessage ="El nombre del producto debe tener entre 3 a 100 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="El precio del producto debe ser mayor a cero")]
        public float Precio { get; set; }
        [Required]
        public string Categoria { get; set; }
    }
}
