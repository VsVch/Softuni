using SMS.Data.Models;
using SMS.ViewModels.Carts;
using SMS.ViewModels.Products;
using SMS.Views.Products;
using System.Collections.Generic;

namespace SMS.Service
{
    public interface IDataHelper
    {
        User GetUserById(string id);

        UserProductsModel GetUserProductsData(string id);

        Product GetProductByCartId(string cartId);

        Product GetProductById(string id);

        Product GetProducts(ProductFormModel model);       

        Cart GetCartById(string id);

        List<DetailsProductModel> GetPdoductsModel(string cardId);

        List<Product> GetPdoducts(string cardId);
    }
}
