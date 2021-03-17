using ASPCoreFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Services
{
    public interface IProductsDataService
    {
        List<ProductModel> AllProducts();
        List<ProductModel> SearchProducts(string seartchItem);
        ProductModel GetByProductId(int Id);
        int Insert(ProductModel product);
        bool Delete(ProductModel prodcut);
        int Update(ProductModel product);

    }
}
