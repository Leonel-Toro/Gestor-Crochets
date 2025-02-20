using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Gestor.Data;
using Microsoft.EntityFrameworkCore;
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
            Ingresos iVenta= _context.Ingresos.OrderByDescending(ingreso => ingreso.fechaModificacion).FirstOrDefault();

            return iVenta != null ? iVenta.valor_hora : 0;
        }

        public static int getValorEntrega(GestorContext _context)
        {
            Ingresos iEntrega = _context.Ingresos.OrderByDescending(ingreso => ingreso.fechaModificacion).FirstOrDefault();

            return iEntrega != null ? iEntrega.valor_entrega : 0;
        }

        public DateOnly getFechaCreacionSoloFecha()
        {
            return DateOnly.FromDateTime(this.fechaCreacion); 
        }

        public static string getProductoPopular(GestorContext _context)
        {
            string query = @"
                        SELECT *
                        FROM ""Ingresos""
                        WHERE ""productoVendidoId"" = (
                            SELECT ""productoVendidoId""
                            FROM ""Ingresos""
                            WHERE borrado = false AND ""productoVendidoId"" IS NOT NULL
                            GROUP BY ""productoVendidoId""
                            ORDER BY COUNT(*) DESC
                            LIMIT 1)
                        LIMIT 1";

            Ingresos iProductoPopular = _context.Ingresos
                    .FromSqlRaw(query)
                    .FirstOrDefault();

            if(iProductoPopular != null)
            {
                Producto pp = _context.Producto.FirstOrDefault(producto => producto.Id == iProductoPopular.productoVendido.Id);
                return pp.Nombre.ToString();
            }
            return "-";
        }

        public static IList<Ingresos> getIngresosHistoricosTrimestral(GestorContext _context)
        {
            DateTime ahora = DateTime.UtcNow;
            DateTime ano = ahora.AddMonths(-4);
            
            IList<Ingresos> listaIngresosAnuales = _context.Ingresos
            .Where(i => i.borrado == false &&
                        i.productoVendido != null &&
                        i.valor_fijo == false &&
                        i.fechaCreacion >= ano &&
                        i.fechaCreacion <= ahora)
            .Select(i => new Ingresos
            {
                Id = i.Id,
                valor_venta = i.valor_venta,
                forma_venta = i.forma_venta,
                valor_entrega = i.valor_entrega,
                valor_hora = i.valor_hora,
                borrado = i.borrado,
                productoVendido = i.productoVendido,
                fechaCreacion = i.fechaCreacion,
                fechaModificacion = i.fechaModificacion
            })
            .ToList();
            return listaIngresosAnuales;
        }
    }
}
