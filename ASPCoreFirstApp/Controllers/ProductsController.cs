using ASPCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<ProductModel> productList = new List<ProductModel>();

            productList.Add(new ProductModel(1, "Mouse Pad", 5.99m, "A square piece of plastic to make mousing easier"));
            productList.Add(new ProductModel(2, "web Cam", 45.99m, "Enables you to attend more zoom meeting"));
            productList.Add(new ProductModel(3, "4 TB USB Hard Drive", 130.99m, "Back up all of your work. You wont regret it"));
            productList.Add(new ProductModel(4, "Wireless Mouse", 15.99m, "Notebook mice really dont work very well do they"));

            return View(productList);
        }
    }
}
