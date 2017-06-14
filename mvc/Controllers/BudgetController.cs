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

        // [HttpPost]
        // public IActionResult Index(decimal ListBudget) {

        //        Budget b = new Budget();
        //      b.totalBalance = ListBudget;
        //        _context.Budget.Add(b);
        //     _context.SaveChanges();
             
        //      if(_context.Budget.Any()) {
        //         decimal total = _context.Budget.Sum(bgt => ( bgt.itemPrice));
        //         decimal balance = ListBudget - total;
        //      }
        //     return View();
        // }
        
        
        public IActionResult index2(){
            

            bool isThereAny =_context.Budget.Any();
            Budget b = new Budget(); 
           
            if(isThereAny){
                 b.itemName= Request.Form["ListItems"].ToString();
                 b.itemPrice = decimal.Parse(Request.Form["ListPrice"]);
                 b.totalBalance = _context.Budget.Last().totalBalance + b.itemPrice;}
            else
            {
                 b.itemName= Request.Form["ListItems"].ToString();
            b.itemPrice = decimal.Parse(Request.Form["ListPrice"]);
              b.totalBalance = b.itemPrice;  
            }
            

            _context.Budget.Add(b);
            _context.SaveChanges();

             var budget = _context.Budget.ToList();
           
             
            return View(budget);

            
        }
        
    }
}