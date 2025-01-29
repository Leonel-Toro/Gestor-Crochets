using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gestor.Modelos
{
    public class Ingresos
    {
        public int Id { get; set; }
        public int valor_venta { get; set; }
        public String forma_venta { get; set; }
        public int valor_hora { get; set; }
        public int valor_entrega { get; set; }
    }
}
