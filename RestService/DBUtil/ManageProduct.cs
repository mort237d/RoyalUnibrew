using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ModelLibrary;

namespace RestService.DBUtil
{
    public class ManageProduct : IManageProduct
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string queryString = "SELECT * FROM Product";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.FinishedProduct_No = reader.GetInt32(0);
                        product.ProductName = reader.GetString(1);

                        products.Add(product);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                finally
                {
                    reader.Close();
                    command.Connection.Close();
                }
            }
            return products;
        }

        public Product GetProductFromID(int finishedProductNo)
        {
            string queryString = $"SELECT * FROM Product WHERE FinishedProduct_No = {finishedProductNo}";
            Product product = new Product();

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        product.FinishedProduct_No = reader.GetInt32(0);
                        product.ProductName = reader.GetString(1);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                finally
                {
                    reader.Close();
                    command.Connection.Close();
                }

                return product;
            }
        }

        public bool CreateProduct(Product product)
        {
            string queryString = "INSERT INTO Product (FinishedProduct_No, ProductName) VALUES (@FinishedProduct_No, @ProductName)";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                
                command.Parameters.AddWithValue("@FinishedProduct_No", product.FinishedProduct_No);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);

                command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public bool UpdateProduct(Product product, int finishedProductNo)
        {
            string queryString = $"UPDATE Product SET FinishedProduct_No = @FinishedProduct_No, ProductName = @ProductName WHERE FinishedProduct_No = {finishedProductNo}";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);

                command.Parameters.AddWithValue("@FinishedProduct_No", product.FinishedProduct_No);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);

                command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public bool DeleteProduct(int finishedProductNo)
        {
            string queryString = $"DELETE FROM Product WHERE FinishedProduct_No = {finishedProductNo}";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
    }
}