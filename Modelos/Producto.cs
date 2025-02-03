using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using NuGet.Packaging.Signing;

namespace Gestor.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Tamaño")]
        public int Tamanio { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}
