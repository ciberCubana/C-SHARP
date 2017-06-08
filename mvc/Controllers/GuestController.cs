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