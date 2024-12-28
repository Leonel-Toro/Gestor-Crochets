using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages.CostoMaterial
{
    public class EditModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public EditModel(Gestor.Data.GestorContext context)
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

            var costomaterial =  await _context.CostoMaterial.FirstOrDefaultAsync(m => m.Id == id);
            if (costomaterial == null)
            {
                return NotFound();
            }
            CostoMaterial = costomaterial;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CostoMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostoMaterialExists(CostoMaterial.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CostoMaterialExists(int id)
        {
            return _context.CostoMaterial.Any(e => e.Id == id);
        }
    }
}
