using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.ViewModels.ProductVM
{
    public class ProductListItemVM
    {
        public ProductListItemVM(Product product)
        {
            ProductID = product.ProductId;
            ProductName = product.ProductName;
            ProductPrice = product.ProductPrice;
        }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductIDNumber { get; set; }
    }
}
