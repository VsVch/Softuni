using System.Collections.Generic;

namespace SMS.ViewModels.Products
{
    public class UserProductsModel
    {
        public string Name { get; set; }

        public List<AllProductsModel> Products { get; set; }
    }
}
