using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Models
{
    public class CarModel
    {
        public CarModel(string carType, int price, DateTime purchaseDate)
        {
            CarType = carType;
            Price = price;
            PurchaseDate = purchaseDate;
        }

        public string CarType { get; set; }

        public int Price { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
