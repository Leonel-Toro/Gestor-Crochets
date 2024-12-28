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
    public class IndexModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public IndexModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public IList<Gestor.Modelos.CostoMaterial> CostoMaterial { get; set; } = default!;
        
        [BindProperty]
        public Gestor.Modelos.CostoMaterial NuevoCostoMaterial { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                CostoMaterial = await _context.CostoMaterial.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NuevoCostoMaterial == null ||
                string.IsNullOrEmpty(NuevoCostoMaterial.Lugar) ||
                string.IsNullOrEmpty(NuevoCostoMaterial.Material) ||
                string.IsNullOrEmpty(NuevoCostoMaterial.Cantidad) ||
                NuevoCostoMaterial.Costo <= 0)
            {
                ModelState.AddModelError(string.Empty, "Todos los campos son obligatorios y el costo debe ser un valor valido.");
            }

            try
            {
                // Agrega el nuevo ítem a la base de datos
                _context.CostoMaterial.Add(NuevoCostoMaterial);
                await _context.SaveChangesAsync();

                // Redirige al usuario después de guardar
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Maneja errores de la base de datos o lógica adicional
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el costo de material.");
                return Page();
            }
        }
    }
}
