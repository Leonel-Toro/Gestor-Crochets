using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Gestor.Data;
using Gestor.Modelos;
using System.Linq;
using ProductoModel = Gestor.Modelos.Producto;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Pages.Producto
{
    public class EditarProductoModel : PageModel
    {
        private readonly GestorContext _context;

        public EditarProductoModel(GestorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductoModel producto { get; set; } = default!;

        [BindProperty]
        public string idProd { get; set; }

        [BindProperty]
        public string nombreProd { get; set; }

        [BindProperty]
        public int tamanioProd { get; set; }

        [BindProperty]
        public IFormFile imgPrincipal { get; set; }

        [BindProperty]
        public IFormFile imgSecundaria { get; set; }

        [BindProperty]
        public IFormFile imgTerciaria { get; set; }

        public async Task<IActionResult> OnGetAsync(int idProd)
        {
            if (idProd == null)
            {
                return NotFound();
            }

            producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == idProd);

            if (producto == null)
            {
                return NotFound();
            }

            return Partial("/Pages/Shared/EditarProducto/EditarProductoPartialView.cshtml", producto);
        }

        public async Task<IActionResult> OnPostEditarProductoAsync()
        {
            ProductoModel producto = await _context.Producto.FirstOrDefaultAsync(prod => prod.Id == int.Parse(idProd));
            string pathImgPrincipal = producto.imgPrincipal != null ? producto.imgPrincipal : null;
            string pathImgSecundaria = producto.imgSecundaria != null ? producto.imgSecundaria : null;
            string pathImgTerciaria = producto.imgTerciaria != null ? producto.imgTerciaria : null;

            if (!string.IsNullOrEmpty(nombreProd))
            {
                producto.Nombre = nombreProd;
            }

            if (tamanioProd < 0 || !tamanioProd.Equals(producto.Tamanio))
            {
                producto.Tamanio = tamanioProd;
            }

            if (imgPrincipal != null)
            {
                pathImgPrincipal = await saveImgProducto(imgPrincipal, producto, "Principal");
                Console.WriteLine(pathImgPrincipal);
            }

            if (imgSecundaria != null)
            {
                pathImgSecundaria = await saveImgProducto(imgSecundaria, producto, "Secundaria");
            }

            if (imgTerciaria != null)
            {
                pathImgTerciaria = await saveImgProducto(imgTerciaria, producto, "Terciaria");
            }

            producto.imgPrincipal = pathImgPrincipal;
            producto.imgSecundaria = pathImgSecundaria;
            producto.imgTerciaria = pathImgTerciaria;
            producto.fechaModificacion = DateTime.UtcNow;

            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        public async Task<string> saveImgProducto(IFormFile imgProducto, ProductoModel producto, string tipoImg)
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            string extensionImg = Path.GetExtension(imgProducto.FileName);
            string nombreImg = $"img_{tipoImg}_{producto.Nombre}_{producto.Id}{extensionImg}";
            string imgPath = Path.Combine(basePath, nombreImg);


            using (FileStream stream = new FileStream(imgPath, FileMode.Create))
            {
                await imgProducto.CopyToAsync(stream);
            }

            return Path.Combine("img", nombreImg);
        }
    }
}
