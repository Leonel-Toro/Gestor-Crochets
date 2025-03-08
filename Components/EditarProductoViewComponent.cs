using Gestor.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductoModel = Gestor.Modelos.Producto;
namespace Gestor.Componentes
{
    public class EditarProductoViewComponent : ViewComponent
    {
        private readonly GestorContext _context;

        public EditarProductoViewComponent(GestorContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int idProd)
        {
            ProductoModel producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == idProd);

            if (producto == null)
            {
                return Content("Producto no encontrado.");
            }

            return View("EditarProductoPartialView",producto);
        }
    }
}
