using Microsoft.AspNetCore.Mvc;
using today.Models;

namespace today.Controllers
{
    public class ProductController: Controller
    {
        [HttpGet]
        public IActionResult Index() {
            Product singleProduct = new Product();
            singleProduct.Category = "DVDs";
            singleProduct.Name = "Batman";
            singleProduct.Price = 5.99m;

            return View(singleProduct);
        }


        [HttpPost]
        public IActionResult Index(Product fromView) {

            string name = fromView.Name;

            return View();
        }
    }
}