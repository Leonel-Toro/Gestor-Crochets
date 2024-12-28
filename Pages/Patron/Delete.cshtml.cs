using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages.Patron
{
    public class DeleteModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public DeleteModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gestor.Modelos.Patron Patron { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patron.FirstOrDefaultAsync(m => m.Id == id);

            if (patron == null)
            {
                return NotFound();
            }
            else
            {
                Patron = patron;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patron.FindAsync(id);
            if (patron != null)
            {
                Patron = patron;
                _context.Patron.Remove(Patron);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
