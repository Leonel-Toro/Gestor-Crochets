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
    public class DetailsModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public DetailsModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public Gestor.Modelos.Ingresos Ingresos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresos = await _context.Ingresos.FirstOrDefaultAsync(m => m.Id == id);
            if (ingresos == null)
            {
                return NotFound();
            }
            else
            {
                Ingresos = ingresos;
            }
            return Page();
        }
    }
}
