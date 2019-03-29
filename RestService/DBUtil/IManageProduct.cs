using System.Collections.Generic;
using ModelLibrary;

namespace RestService.DBUtil
{
    interface IManageProduct
    {
        List<Product> GetAllProducts();

        Product GetProductFromID(int finishedProductNo);

        bool CreateProduct(Product product);

        bool UpdateProduct(Product product, int finishedProductNo);

        bool DeleteProduct(int finishedProductNo);
    }
}
