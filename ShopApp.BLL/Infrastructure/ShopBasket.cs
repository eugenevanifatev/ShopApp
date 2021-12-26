using ShopApp.BLL.ViewModels.ProductVM;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Infrastructure
{
    public static class ShopBasket
    {
        public static List<ProductListItemVM> productInBasket = new List<ProductListItemVM>();
    }
}
