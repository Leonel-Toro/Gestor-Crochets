using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using Gestor.Data;
using NuGet.Packaging.Signing;

namespace Gestor.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Tamaño")]
        public int Tamanio { get; set; }

        [Column("path_img_principal")]
        public string? imgPrincipal { get; set; }

        [Column("path_img_secundaria")]
        public string? imgSecundaria { get; set; }

        [Column("path_img_terciaria")]
        public string? imgTerciaria { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }


        public static List<Producto> listaProductosRecientes(GestorContext _context)
        {
            List<Producto> listaProd = _context.Producto.Where(prod => prod.imgPrincipal != null)
                .OrderByDescending(prod => prod.fechaCreacion)
                .Take(6)
                .ToList();

            return listaProd;
        }
    }
}
