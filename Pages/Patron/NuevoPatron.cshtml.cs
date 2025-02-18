using System.Text.Json;
using Gestor.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestor.Pages.Patron
{
    public class NuevoPatronModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public NuevoPatronModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gestor.Modelos.Patron NuevoPatron { get; set; } = default!;

        [BindProperty]
        public int idProducto { get; set; }

        [BindProperty]
        public string idListaTPCantidad { get; set; }

        [BindProperty]
        public int Vuelta { get; set; }

        [BindProperty]

        public int Repeticiones { get; set; }

        [BindProperty]
        public string Parte { get; set; }
        public IList<Gestor.Modelos.Patron> Patron { get; set; } = default!;

        public Gestor.Modelos.Producto Producto { get; set; } = default!;

        public IList<Gestor.Modelos.Tipo_punto> Tipo_punto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? idProducto)
        {
            Tipo_punto = await _context.Tipo_punto.ToListAsync();

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
            Tipo_punto = await _context.Tipo_punto.ToListAsync();
            String[] listaPartes = idListaTPCantidad.Split(';');
            try
            {
                if (listaPartes.Length>1)
                {
                    foreach(string tpCantidad in listaPartes)
                    {
                        String[] parteTpCantidad = tpCantidad.Split("-");
                        string tipoPunto = parteTpCantidad[0];
                        int cantidad = int.Parse(parteTpCantidad[1]);

                        NuevoPatron.vuelta = Vuelta;
                        NuevoPatron.producto = Producto;
                        NuevoPatron.punto = tipoPunto;
                        NuevoPatron.cantidad = cantidad;
                        NuevoPatron.parte = Parte;
                        NuevoPatron.repeticiones = Repeticiones;
                        NuevoPatron.fechaCreacion = ahora;
                        NuevoPatron.fechaModificacion = ahora;

                        _context.Patron.Add(NuevoPatron);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    String[] parteTpCantidad = idListaTPCantidad.Split("-");
                    string tipoPunto = parteTpCantidad[0];
                    int cantidad = int.Parse(parteTpCantidad[1]);
                    NuevoPatron.vuelta = Vuelta;
                    NuevoPatron.producto = Producto;
                    NuevoPatron.punto = tipoPunto;
                    NuevoPatron.cantidad = cantidad;
                    NuevoPatron.parte = Parte;
                    NuevoPatron.repeticiones = Repeticiones;
                    NuevoPatron.fechaCreacion = ahora;
                    NuevoPatron.fechaModificacion = ahora;

                    _context.Patron.Add(NuevoPatron);
                    await _context.SaveChangesAsync();
                }

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
