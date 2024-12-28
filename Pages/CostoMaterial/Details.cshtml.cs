using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages.CostoMaterial
{
    public class DetailsModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public DetailsModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public Gestor.Modelos.CostoMaterial CostoMaterial { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costomaterial = await _context.CostoMaterial.FirstOrDefaultAsync(m => m.Id == id);
            if (costomaterial == null)
            {
                return NotFound();
            }
            else
            {
                CostoMaterial = costomaterial;
            }
            return Page();
        }
    }
}
