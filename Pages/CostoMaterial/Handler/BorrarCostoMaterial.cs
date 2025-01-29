using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Gestor.Pages.CostoMaterial.Handler
{
    [Route("CostoMaterial/[controller]")]
    public class BorrarCostoMaterial : ControllerBase
    {
        private readonly Gestor.Data.GestorContext _context;

        public BorrarCostoMaterial(Gestor.Data.GestorContext context)
        {
            _context = context;
        }

        [HttpPost("EliminarCostoMaterial")]
        public async Task<IActionResult> EliminarCostoMaterial([FromBody] JsonElement data)
        { 
            var idMaterial = data.GetProperty("idMaterial").GetInt32();
            var CM = await _context.CostoMaterial.FirstOrDefaultAsync(cm => cm.Id == idMaterial);

            if (CM != null)
            {
                CM.eliminado = true;
                _context.CostoMaterial.Update(CM);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true ,message = "Se ha eliminado el material correctamente."});
            }
            else
            {
                return new JsonResult(new { success = false , message = "No se ha podido eliminar el material." });
            }
        }
    }
}
