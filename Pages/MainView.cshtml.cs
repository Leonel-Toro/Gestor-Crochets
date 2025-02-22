using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestor.Data;
using Gestor.Modelos;

namespace Gestor.Pages
{
    public class MainView : PageModel
    {
        private readonly Gestor.Data.GestorContext _context;

        public MainView(Gestor.Data.GestorContext context)
        {
            _context = context;
        }
        public List<Gestor.Modelos.Producto> listaImgProductos { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["Header"] = "Principal";
            listaImgProductos = Gestor.Modelos.Producto.listaProductosRecientes(_context);

        }
    }
}
