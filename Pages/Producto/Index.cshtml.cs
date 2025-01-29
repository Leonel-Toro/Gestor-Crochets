using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages.Producto
{
    public class IndexModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public IndexModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public IList<Gestor.Modelos.Producto> Producto { get;set; } = default!;

        [BindProperty]
        public Gestor.Modelos.Producto NuevoProducto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Producto = await _context.Producto.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NuevoProducto == null || string.IsNullOrEmpty(NuevoProducto.Nombre)
                || NuevoProducto.Tamanio <= 0)
            {
                ModelState.AddModelError(string.Empty, "Todos los campos son obligatorios y el costo debe ser un valor valido.");
                return Page();
            }

            try
            {
                _context.Producto.Add(NuevoProducto);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
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
