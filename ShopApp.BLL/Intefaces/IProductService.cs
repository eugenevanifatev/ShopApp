using ShopApp.BLL.ViewModels.ProductVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    public interface IProductService
    {
        bool AddProduct(CreateProductVM createProductVM);
        List<ProductListItemVM> GetAllProductsByCategory(Guid categoryId);
        void AddProductToOrder();
        CreateProductVM ViewProduct(Guid productId);

    }
}
