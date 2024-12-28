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
    public class DeleteModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public DeleteModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costomaterial = await _context.CostoMaterial.FindAsync(id);
            if (costomaterial != null)
            {
                CostoMaterial = costomaterial;
                _context.CostoMaterial.Remove(CostoMaterial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
