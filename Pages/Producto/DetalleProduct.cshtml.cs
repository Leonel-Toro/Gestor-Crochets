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
    public class DetalleProductModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public DetalleProductModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public Gestor.Modelos.Producto productoDetalle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                productoDetalle = producto;
            }
            return Page();
        }
    }
}
