using ASPCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Controllers
{
    public class CustomerController : Controller
    {
        List<CustomerModel> customers = new List<CustomerModel>();
        public CustomerController ()
        {
            customers.Add(new CustomerModel(0, "Don", 42));
            customers.Add(new CustomerModel(1, "Melvin", 18));
            customers.Add(new CustomerModel(2, "Jerry", 25));
            customers.Add(new CustomerModel(3, "Velma", 45));
            customers.Add(new CustomerModel(4, "Wendy", 33));
            customers.Add(new CustomerModel(5, "Kim", 90));
          
        }

        public IActionResult Index()
        {
            return View(customers);
        }
        public IActionResult ShowOnePerson(int Id)
        {
            return PartialView(customers.FirstOrDefault(c => c.Id == Id));
        }
    }
}
