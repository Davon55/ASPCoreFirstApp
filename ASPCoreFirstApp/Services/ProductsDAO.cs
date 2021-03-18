using ASPCoreFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstAPP.Services
{
    public class ProductsDAO : IProductsDataService
    {
        //copy this string from the products database properties values
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ProductModel> AllProducts()
        {
            //assume nothing is found
            List<ProductModel> foundProducts = new List<ProductModel>();

            //uses preprared statements for security @usernae @password are defined below
            string sqlStatment = "SELECT * FROM dbo.Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;
        }

        public bool Delete(ProductModel product)
        {
            //return -1 if the update fails
            bool deletedId = true;

            //uses preprared statements for security @usernae @password are defined below
            string sqlStatment = "DELETE FROM dbo.Products WHERE WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                
                try
                {
                    connection.Open();
             deletedId = Convert.ToBoolean(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return deletedId;
        }
    

        public ProductModel GetByProductId(int Id)
        {
            //assume nothing is found
            ProductModel foundProducts = null;

            //uses preprared statements for security @usernae @password are defined below
            string sqlStatment = "SELECT * FROM dbo.Products Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                //define the values of the two placeholders in the sql statement string
                command.Parameters.AddWithValue("@Id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts = (new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;
        }
    

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string seartchItem)
        {
            //assume nothing is found
            List<ProductModel> foundProducts = new List<ProductModel>();

            //uses preprared statements for security @usernae @password are defined below
            string sqlStatment = "SELECT * FROM dbo.Products Where Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                //define the values of the two placeholders in the sql statement string
                command.Parameters.AddWithValue("@Name", '%' + seartchItem);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;
        }
    

        public int Update(ProductModel product)
        {
            //return -1 if the update fails
            int newIdNumber = -1;

            //uses preprared statements for security @usernae @password are defined below
            string sqlStatment = "UPDATE dbo.Products SET NAME = @Name, Price = @Price, Description= @Description WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Id",product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newIdNumber ;
        }
    }
}
