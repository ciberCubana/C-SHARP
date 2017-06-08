using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Models;


namespace mvc.Controllers
{
    public class GuestController : Controller
    {
       
          private readonly GuestContext1 _context;

        public GuestController(GuestContext1 context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateList()
        {
            var guest = _context.Guest.ToList();
            
            return View(guest);
        }

        public IActionResult GuestConfirm()
        {
            var guest1 = _context.Guest.ToList();
            var guestConfirmed = from guest in guest1
                           where guest.status == "Confirmed"
                           select guest;
            return View(guestConfirmed);
        }
        
        
        public IActionResult GuestList()
        {
            // Guest g = new Guest();
            // g.nameGuest= Request.Form["guestname"].ToString();
            // g.email = Request.Form["email"].ToString();
           var guest = _context.Guest.ToList();
           
        //    var quantity = Request.Form["quantity"];
            return View(guest);
        }


        // public IActionResult Index()  {
           
        //     return View();
        // }

        
    // public IActionResult Index(Guest g)  
    //     {         
            
    //         string json = JsonConvert.SerializeObject(g);
    //         string fileName = "guestList.txt";
    //         System.IO.File.WriteAllText(fileName, json); 
    //         return View(); 
    //     }   

        
    }
}