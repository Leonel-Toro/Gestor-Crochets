using NuGet.Packaging.Signing;

namespace Gestor.Modelos
{
    public class ImagenProducto
    {
        public int Id { get; set; }
        public Producto producto { get; set; }
        public string rutaImg { get; set; }
        public Boolean borrado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}
