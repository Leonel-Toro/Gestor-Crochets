using System.Text.Json;
using Gestor.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using PatronModel = Gestor.Modelos.Patron;
using TipoPunto = Gestor.Modelos.Tipo_punto;

namespace Gestor.Pages.Patron
{
    public class NuevoPatronModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public NuevoPatronModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }
        //public Gestor.Modelos.Patron NuevoPatron { get; set; } = default!;
        public Gestor.Data.GestorContext Context => _context;

        [BindProperty]
        public string Parte { get; set; }

        [BindProperty]
        public string TipoPunto { get; set; }

        [BindProperty]
        public int idProducto { get; set; }

        [BindProperty]
        public int Vuelta { get; set; }

        [BindProperty]
        public string Color { get; set; }

        public IList<Gestor.Modelos.Patron> Patron { get; set; } = default!;

        public Gestor.Modelos.Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? idProducto)
        {
            if (idProducto == null)
            {
                return Redirect("/Patron");
            }

            Producto = await _context.Producto.FirstOrDefaultAsync(prod => prod.Id == idProducto);
            Patron = await _context.Patron.Where(patron => patron.producto.Id == idProducto && !patron.eliminado).ToListAsync();

            if (Producto == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            DateTime ahora = DateTime.UtcNow;
            Producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == idProducto);
            PatronModel nuevoPatron = new PatronModel();
            TipoPunto nuevoTipoPunto = new TipoPunto();

            if (Parte.IsNullOrEmpty() || Parte.Equals("Parte")) 
            {
                Console.WriteLine("ERROR: PARTE NO DEBE ESTAR VACIO.");
                return Page();
            }
            if (TipoPunto.IsNullOrEmpty())
            {
                Console.WriteLine("ERROR: TIPO PUNTO NO DEBE ESTAR VACIO.");
                return Page();
            }

            try
            {
                nuevoPatron.producto = Producto;
                nuevoPatron.fechaCreacion = ahora;
                nuevoPatron.fechaModificacion = ahora;
                nuevoPatron.parte = Parte.Trim();
                _context.Patron.Add(nuevoPatron);
                await _context.SaveChangesAsync();

                nuevoTipoPunto.nombre = TipoPunto;
                nuevoTipoPunto.vuelta = Vuelta;
                nuevoTipoPunto.color = Color;
                nuevoTipoPunto.idPatron = nuevoPatron;
                nuevoTipoPunto.fechaCreacion = ahora;
                nuevoTipoPunto.fechaModificacion = ahora;

                _context.Tipo_punto.Add(nuevoTipoPunto);
                await _context.SaveChangesAsync();

                return RedirectToPage("./NuevoPatron", new { idProducto = idProducto });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el costo de material.");
                return Page();
            }

        }
    }
}
