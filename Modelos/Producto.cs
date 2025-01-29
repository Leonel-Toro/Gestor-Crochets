using System.ComponentModel.DataAnnotations;

namespace Gestor.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Tamaño")]
        public int Tamanio { get; set; }

    }
}
