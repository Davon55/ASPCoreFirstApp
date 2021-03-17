using ASPCoreFirstApp.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Services
{
    public class HardCodedSampleDataRepository : IProductsDataService

    {
        //use static to ensure the data set does not change
        static List<ProductModel> productList;

        //create the list in the constructor of the service
        public HardCodedSampleDataRepository()
        {
            List<ProductModel> productList = new List<ProductModel>();

            productList.Add(new ProductModel(1, "Mouse Pad", 5.99m, "A square piece of plastic to make mousing easier"));
            productList.Add(new ProductModel(2, "web Cam", 45.99m, "Enables you to attend more zoom meeting"));
            productList.Add(new ProductModel(3, "4 TB USB Hard Drive", 130.99m, "Back up all of your work. You wont regret it"));
            productList.Add(new ProductModel(4, "Wireless Mouse", 15.99m, "Notebook mice really dont work very well do they"));
            for (int i = 0; i < 100; i++)
            {
                productList.Add(new Faker<ProductModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.Description, f => f.Rant.Review())
                    );



            }
        }
        public List<ProductModel> AllProducts()
        {
            return productList;
        }

        public bool Delete(ProductModel prodcut)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetByProductId(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string seartchItem)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
