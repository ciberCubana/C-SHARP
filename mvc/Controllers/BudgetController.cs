using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Linq;
using System;
namespace mvc.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult BudgetList()
        {
            // ViewData["Message"] = "Testing the budget description page.";

            // return View();
            Budget theCost = new Budget(); // create an instance of budget
            theCost.itemName= Request.Form["ListItems"].ToString();
            theCost.itemPrice= Convert.ToDecimal(Request.Form["ListPrice"]);
            theCost.MaxBudget= Convert.ToDecimal(Request.Form["ListBudget"]);

            List <Budget> cost = new List<Budget> ();
            cost.Add(new Budget(){itemName=theCost.itemName, itemPrice = theCost.itemPrice});
            

            // theCost.MaxBudget -= theCost.itemPrice;
            return View(cost);
        }

        public IActionResult Index()  {
           
            return View();
        }
        
    }
}