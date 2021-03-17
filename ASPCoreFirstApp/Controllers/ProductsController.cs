using ASPCoreFirstApp.Models;
using ASPCoreFirstAPP.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO repository = new ProductsDAO();

        public ProductsController()
        {
            repository = new ProductsDAO();
        }
        public IActionResult Index()
        {
            return View(repository.AllProducts());
           
        }
        public IActionResult SearchResults(string searchItem)
        {
            List<ProductModel> productsList = repository.SearchProducts(searchItem);
            return View("Index", productsList);
        }
        public IActionResult SearchForm()
        {
            return View();
        }

    }
}
