using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;
using ProductoModel = Gestor.Modelos.Producto;

namespace Gestor.Pages.PaginaProducto
{
    public class IndexModel : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public IndexModel(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        public IList<ProductoModel> listaProductos { get;set; } = default!;

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
        public async Task OnGetAsync()
        {
            listaProductos = await _context.Producto.OrderByDescending(prod => prod.fechaCreacion).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ProductoModel nuevoProducto = new ProductoModel();

            if (nombreProd == null || nombreProd.Equals(""))
            {
                ModelState.AddModelError("nombreProd", "Nombre no puede estar vacio.");
                return Redirect("./Producto");
            }

            if (tamanioProd<0)
            {
                ModelState.AddModelError("tamanioProd", "Cantidad no puede estar vacio y debe ser mayor a 0.");
                return Redirect("./Producto");
            }

            nuevoProducto.Nombre = nombreProd;
            nuevoProducto.Tamanio = tamanioProd;
            nuevoProducto.fechaCreacion = DateTime.UtcNow;
            nuevoProducto.fechaModificacion = DateTime.UtcNow;

            _context.Producto.Add(nuevoProducto);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostEditarProductoAsync()
        {
            ProductoModel producto = await _context.Producto.FirstOrDefaultAsync(prod => prod.Id == Int32.Parse(idProd));
            string pathImgPrincipal = null;
            string pathImgSecundaria = null;
            string pathImgTerciaria = null;

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

            return Path.Combine("img",nombreImg);
        }

    }
}
