using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Linq;
using System;

namespace mvc.Controllers

{
    public class ProductsController : Controller
    {
        public IActionResult Index(){
           List<Products> inventory = new List <Products>();
           inventory.Add(new Products(){Name = "Shoes", Price = 120.00m});
           inventory.Add(new Products(){Name = "T-Shirt", Price = 100.00m});
           inventory.Add(new Products(){Name = "Glasses", Price = 150.00m});
           inventory.Add(new Products(){Name = "Hat", Price = 200.00m});

           var x = new {Price = 5};

          
            
           Func< int , int, int> add = (int z, int y) => {return z+y;};

           inventory.Where(p => p.Name.StartsWith("G"))
                    .Select(p => new {p.Price});
        
        return View(inventory);
        }

        static void Sort(Func<int,int> someFunction)
        {
            int x = someFunction(2);
        }
    }
}