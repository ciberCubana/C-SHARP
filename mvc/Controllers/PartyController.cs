using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class PartyController : Controller
    {
        public IActionResult Party()
        {
            Party obj = new Party();
            obj.name= Request.Form["name"].ToString();
           obj.kind = Request.Form["kind"];
           obj.date = Request.Form["date"];
            obj.message = Request.Form["msg"].ToString();
            obj.venue = Request.Form["venue"].ToString();

            return View(obj);
        }
        public IActionResult Index()  //Party fromView
        {
           // string name = fromView.name;
           
            return View();
        }

        
    }
}