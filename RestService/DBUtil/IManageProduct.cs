using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
