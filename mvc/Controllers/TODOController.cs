using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class TODOController : Controller
    {
        public IActionResult TODO()
        {
            

            return View();
        }
        public IActionResult Index()  {
           
            return View();
        }

        
    }
}