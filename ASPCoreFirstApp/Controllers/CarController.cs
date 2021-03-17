using ASPCoreFirstAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            List<CarModel> carList = new List<CarModel>();

            carList.Add(new CarModel("Charger", 75000, DateTime.Now));
            carList.Add(new CarModel("Challenger", 55000, DateTime.Now));
            carList.Add(new CarModel("Durango", 85000, DateTime.Now));
            carList.Add(new CarModel("Viper", 175000, DateTime.Now));
            return View(carList);
        }
    }
}
