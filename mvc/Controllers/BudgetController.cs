using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Linq;
using System;
namespace mvc.Controllers
{
    public class BudgetController : Controller
    {
       private readonly GuestContext1 _context;

        public BudgetController(GuestContext1 context)
        {
            _context = context;
        }
        
        public IActionResult index (){
            return View();
        }
        
        
        public IActionResult index2(){
            
            Budget b = new Budget(); 
            b.itemName= Request.Form["ListItems"].ToString();
            b.itemPrice= Request.Form["ListPrice"].ToString();

            _context.Budget.Add(b);
            _context.SaveChanges();
             var budget = _context.Budget.ToList();
           

            return View(budget);

            
        }
        
    }
}