using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Gestor.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace Gestor.Modelos
{
    public class Patron
    {
        public int Id { get; set; }

        public Producto producto { get; set; }
        public string parte { get; set; }
        public Boolean eliminado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }

        private readonly Gestor.Data.GestorContext _context;

        public Patron(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public Patron()
        {
        }

        public List<Tipo_punto> getListaTipoPuntoByPatron()
        {
            List<Tipo_punto> listaTp = _context.Tipo_punto.Where(tp => tp.idPatron.Id == this.Id).ToList();

            return listaTp;
        }
    }
}
