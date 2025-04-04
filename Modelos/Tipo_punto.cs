namespace Gestor.Modelos
{
    public class Tipo_punto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Patron idPatron { get; set; }
        public int vuelta { get; set; }
        public string color { get; set; }
        public Boolean eliminado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }

    }
}
