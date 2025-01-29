using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Modelos
{
    public class Patron
    {
        public int Id { get; set; }

        public Producto producto { get; set; }

        public string parte { get; set; }

        public string punto { get; set; }

        public int repeticiones { get; set; }

        public Boolean eliminado { get; set; }

        public int vuelta { get; set; }

    }
}
