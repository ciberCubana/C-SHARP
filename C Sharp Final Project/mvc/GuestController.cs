using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult GuestList()
        {
            Guest g = new Guest();
            g.nameGuest= Request.Form["guestname"].ToString();
        //    g.childs = Request.Form["kind"];
        //    g.numberPersons = Request.Form["date"];
        //     g.numberTable = Request.Form["msg"].ToString();
        //     g.status = Request.Form["venue"].ToString();

            return View(g);
        }
        public IActionResult Index()  {
           
            return View();
        }

        
    }
}