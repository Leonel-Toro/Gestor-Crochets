using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages.Ingresos
{
    public class CreateModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public CreateModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            FormaVenta = new List<string>
            {
                Gestor.Modelos.FormaVenta.VENTA_DIRECTA,
                Gestor.Modelos.FormaVenta.VENTA_FACEBOOK,
                Gestor.Modelos.FormaVenta.VENTA_INSTAGRAM,
                Gestor.Modelos.FormaVenta.VENTA_OTRO
            };

            return Page();
        }

        [BindProperty]
        public Gestor.Modelos.Ingresos Ingresos { get; set; } = default!;

        public List<string> FormaVenta { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ingresos.Add(Ingresos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
