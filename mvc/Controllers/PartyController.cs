using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers
{
    public class PartyController : Controller
    {
        private readonly GuestContext1 _context;

        public PartyController(GuestContext1 context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        // public IActionResult Party(){
        //     bool isThereAny = _context.Party.Any();
        //      if (isThereAny)
        //     {
        //         var party = _context.Party.ToList();
        //         return View(party);
        //     }
        //     else
        //     {

        //         Party obj = new Party();
        //         obj.name = Request.Form["name"].ToString();
        //         obj.kind = Request.Form["kind"];
        //         obj.date = Request.Form["date"];

        //         obj.message = Request.Form["msg"].ToString();
        //         obj.venue = Request.Form["venue"].ToString();

        //         // _context.Party.Add(obj);
        //         // _context.SaveChanges();

        //         // var party = _context.Party.ToList();

        //         return View(obj);

        //     }

        // }
        public IActionResult Party()
        {


            Party obj = new Party();
            obj.name = Request.Form["name"].ToString();
            obj.kind = Request.Form["kind"];
            obj.date = Request.Form["date"];

            obj.message = Request.Form["msg"].ToString();
            obj.venue = Request.Form["venue"].ToString();

            return View(obj);
        }

    }
}

// public IActionResult Index()  //Party fromView
// {
//     if (!Request.Cookies.ContainsKey("cookie_visited"))
//     {
//         Response.Cookies.Append(
//              "cookie_visited",
//              "yes",
//              new CookieOptions()
//              {
//                  Path = "/",
//                  HttpOnly = false,
//                  Secure = false
//              }
//          );
//     }
//     else
//     {
//         return View("Party/Party");
//     }

//     return View();
// }


