using Microsoft.AspNetCore.Mvc;

namespace Gestor.Pages.Patron
{
    [Route("NuevaParte")]
    public class NuevaParte : Controller
    {
        [HttpGet("NuevaParteVista")]
        public IActionResult NuevaParteVista(int idParte)
        {
            return PartialView("~/Pages/Shared/NuevaPartePatron/_NuevaPartePatronPartialView.cshtml", idParte);
        }
    }
}
