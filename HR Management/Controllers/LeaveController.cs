using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Controllers
{
    public class LeaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
