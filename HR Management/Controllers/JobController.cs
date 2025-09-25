using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
