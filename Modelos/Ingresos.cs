using System.ComponentModel.DataAnnotations;
using Gestor.Data;
using Microsoft.Extensions.Options;
using Producto = Gestor.Modelos.Producto;

namespace Gestor.Modelos
{
    public class Ingresos
    {
        public int Id { get; set; }
        public int? valor_venta { get; set; }
        public String? forma_venta { get; set; }
        public int valor_hora { get; set; }
        public int valor_entrega { get; set; }
        public Producto? productoVendido { get; set; }
        public Boolean? valor_fijo { get; set; } = false;
        public Boolean? borrado { get; set; } = false;
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }

        public static int getValorVenta(GestorContext _context)
        {
            Ingresos iVenta= _context.Ingresos.OrderByDescending(ingreso => ingreso.fechaCreacion).FirstOrDefault();

            return iVenta != null ? iVenta.valor_hora : 0;
        }

        public static int getValorEntrega(GestorContext _context)
        {
            Ingresos iEntrega = _context.Ingresos.OrderByDescending(ingreso => ingreso.fechaCreacion).FirstOrDefault();

            return iEntrega != null ? iEntrega.valor_entrega : 0;
        }

    }
}
