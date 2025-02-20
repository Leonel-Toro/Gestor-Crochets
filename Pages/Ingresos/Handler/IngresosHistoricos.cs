using System.Text.Json;
using Gestor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ingreso = Gestor.Modelos.Ingresos;

namespace Gestor.Pages.Ingresos.Handler
{
    [Route("Ingresos/[controller]")]
    public class IngresosHistoricos : Controller
    {
        private readonly Gestor.Data.GestorContext _context;

        public IngresosHistoricos(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        [HttpGet("IngresosTrimestrales")]
        public IActionResult IngresosTrimestrales ()
        {
            IList<Ingreso> ingresosTrimestrales = Ingreso.getIngresosHistoricosTrimestral(_context);

            return Ok(ingresosTrimestrales);
        }
    }
}
