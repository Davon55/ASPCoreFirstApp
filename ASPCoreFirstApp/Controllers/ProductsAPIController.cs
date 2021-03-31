using ASPCoreFirstApp.Models;
using ASPCoreFirstAPP.Models;
using ASPCoreFirstAPP.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace ASPCoreFirstAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsAPIController : ControllerBase
    {
        ProductsDAO repository = new ProductsDAO();

        public ProductsAPIController()
        {
           repository = new ProductsDAO();
        }

        //no route specified since this is the default 
        // api/productsapi
        [HttpGet]
        [ResponseType(typeof(List < ProductsDTO>))]
        public ActionResult <IEnumerable<ProductModel>> Index()
        {
            //get the products
            List<ProductModel> productList = repository.AllProducts();
            //translate to DTO
            IEnumerable<ProductsDTO> productDTOList = from p in productList
                                                      select
                                                      new ProductsDTO(p.Id, p.Name, p.Price, p.Description);

            return productList;
           
        }

        [HttpGet("searchresults/{searchTerm}")]
        //GET /api/productssapi/searchresults/xyz
        public IEnumerable<ProductsDTO> SearchResults(string searchItem)
        {
            List<ProductModel> productsList = repository.SearchProducts(searchItem);

            //translate to DTO
            List<ProductsDTO> productDTOList = new List<ProductsDTO>();
            foreach (ProductModel p in productsList)
            {
                productDTOList.Add(new ProductsDTO(p.Id, p.Name, p.Price, p.Description));
            }
            return productDTOList;
        }

        //not used in a REST api. This method retunrs a data entry form
        //public IActionResult SearchForm()
        //{
        //    return View();
        //}

        [HttpGet("showoneproduct/{Id}")]
        [ResponseType(typeof(ProductsDTO))]
        // GET /api/productsapi/showoneproduct/3
        public ActionResult<ProductsDTO> ShowOneProduct(int id)
        {
            // get the correct product from the database 
            ProductModel product = repository.GetByProductId(id);
            //create a new DTO based on the Product
            ProductsDTO productsDTO = new ProductsDTO(product.Id, product.Name, product.Price, product.Description);

            //return the DTO instead of the product
            return productsDTO;
        }

        //Not used in REST api
        //public IActionResult ShowEditForm(int id)
        //{
        //    return View(repository.GetByProductId(id));
        //}

        [HttpPut("processedit")]
        //GET /api/productsapi/processedit/product
        public IEnumerable<ProductsDTO> ProccessEdit(ProductModel product)
        {
            repository.Update(product);
            List<ProductModel> productList = repository.AllProducts();

            //translate into DTO
            IEnumerable<ProductsDTO> productsDTOList = from p in productList
                                                       select new ProductsDTO(p.Id, p.Name, p.Price, p.Description);
            return productsDTOList;
        }

        [HttpPut("processeditreturn")]
        //GET /api/productsapi/processeditreturn/products
        public ActionResult<ProductsDTO> ProcessEditReturn(ProductModel product)
        {
            repository.Update(product);
            ProductModel updateProduct = repository.GetByProductId(product.Id);
            ProductsDTO productsDTO = new ProductsDTO(product.Id, product.Name, product.Price, product.Description);

            return productsDTO;
        }
        [HttpPut("deletebyid")]
        //GET /api/productsapi/deletebyid/products
        public ActionResult<IEnumerable<ProductModel>> DeleteById(ProductModel product)
        {
            repository.Delete(product);
            return  repository.AllProducts();
        }


    }
}
