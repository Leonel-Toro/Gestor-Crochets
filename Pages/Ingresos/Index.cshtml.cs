using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages.Ingresos
{
    public class IndexModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public IndexModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public IList<Gestor.Modelos.Ingresos> Ingresos { get;set; } = default!;

        [BindProperty]
        public Gestor.Modelos.Ingresos Ingreso { get; set; } = default!;

        public List<string> FormaVenta { get; set; } = default!;

        public async Task OnGetAsync()
        {
            FormaVenta = new List<string>
            {
                Gestor.Modelos.FormaVenta.VENTA_DIRECTA,
                Gestor.Modelos.FormaVenta.VENTA_FACEBOOK,
                Gestor.Modelos.FormaVenta.VENTA_INSTAGRAM,
                Gestor.Modelos.FormaVenta.VENTA_OTRO
            };
            Ingresos = await _context.Ingresos.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Ingresos.AddAsync(Ingreso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
