using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;
using Ingreso = Gestor.Modelos.Ingresos;
using Productos = Gestor.Modelos.Producto;
using FormaVenta = Gestor.Modelos.FormaVenta;



namespace Gestor.Pages.PaginaIngresos
{
    public class IndexModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public IndexModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public IList<Ingreso> listaIngresos { get;set; } = default!;

        [BindProperty]
        public int valorVenta { get; set; } = default!;
        [BindProperty]
        public string formaEntrega { get; set; } = default!;
        [BindProperty]
        public int valorHora { get; set; } = default!;
        [BindProperty]
        public int valorEntrega { get; set; } = default!;
        [BindProperty]
        public int idProducto { get; set; } = default!;
        public List<string> listaFormaVenta { get; set; } = default!;
        public List<Productos> listaProductos { get; set; } = default!;
        public int ultimoValorHora { get; set;} = default!;
        public int ultimoValorEntrega { get; set; } = default!;

        public async Task OnGetAsync()
        {
            listaFormaVenta = new List<string>
            {
                FormaVenta.VENTA_DIRECTA,
                FormaVenta.VENTA_FACEBOOK,
                FormaVenta.VENTA_INSTAGRAM,
                FormaVenta.VENTA_OTRO
            };
            listaIngresos = await _context.Ingresos.ToListAsync();
            listaProductos = await _context.Producto.ToListAsync();

            ultimoValorHora = Ingreso.getValorVenta(_context);
            ultimoValorEntrega = Ingreso.getValorEntrega(_context);


        }

        public async Task<IActionResult> OnPostGuardarValoresAsync()
        {
            Productos productoVendido = await _context.Producto.FirstOrDefaultAsync(p => p.Id == idProducto);
            Ingreso nuevoIngreso = new Ingreso();
            DateTime ahora = DateTime.UtcNow;
            
            nuevoIngreso.valor_venta = valorVenta;
            nuevoIngreso.forma_venta = formaEntrega;
            nuevoIngreso.productoVendido = productoVendido;
            nuevoIngreso.valor_hora = valorHora;
            nuevoIngreso.valor_entrega = valorEntrega;
            nuevoIngreso.fechaCreacion = ahora;
            nuevoIngreso.fechaModificacion = ahora;

            await _context.Ingresos.AddAsync(nuevoIngreso);
            await _context.SaveChangesAsync();

            return Redirect("/Ingresos");
        }

        public async Task<IActionResult> OnPostEditarValoresAsync()
        {
            Ingreso nuevosValoresFijos = new Ingreso();
            DateTime ahora = DateTime.UtcNow;

            nuevosValoresFijos.valor_hora = valorHora;
            nuevosValoresFijos.valor_entrega = valorEntrega;
            nuevosValoresFijos.valor_fijo = true;
            nuevosValoresFijos.fechaCreacion = ahora;
            nuevosValoresFijos.fechaModificacion = ahora;

            await _context.Ingresos.AddAsync(nuevosValoresFijos);
            await _context.SaveChangesAsync();

            return Redirect("/Ingresos");
        }
    }
}
