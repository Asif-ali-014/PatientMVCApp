using Microsoft.AspNetCore.Mvc;

namespace PatientMVCApp.Controllers
{
    public class LogsController : Controller
    {
        public IActionResult Index()
        {
            return View(PatientController.logs);
        }
    }
}
