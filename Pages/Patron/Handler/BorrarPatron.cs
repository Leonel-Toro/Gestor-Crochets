using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Gestor.Pages.Patron.Handler
{
    [Route("Patron/[controller]")]
    public class BorrarPatron : ControllerBase
    {
        private readonly Gestor.Data.GestorContext _context;

        public BorrarPatron(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        [HttpPost("EliminarPatron")]
        public async Task<IActionResult> EliminarPatron([FromBody] JsonElement data)
        { 
            var idPatron = data.GetProperty("idPatron").GetInt32();
            var patron = await _context.Patron.FirstOrDefaultAsync(p => p.Id == idPatron);

            if (patron != null)
            {
                patron.eliminado = true;
                _context.Patron.Update(patron);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true ,message = "Se ha eliminado el patron correctamente."});
            }
            else
            {
                return new JsonResult(new { success = false , message = "No se ha podido eliminar el patron."});
            }
        }
    }
}
