using ShopApp.BLL.Infrastructure;
using ShopApp.BLL.Intefaces;
using ShopApp.BLL.ViewModels.ProductVM;
using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Services
{
    public class ShopBasketService : IShopBasketService
    {
        private AppDbContext DB { get; set; }
        public ShopBasketService(AppDbContext _db)
        {
            DB = _db;
        }

        public void AddProductToBasket(Guid ProductId)
        {
            var productDb = DB.Products.Find(ProductId);
            ShopBasket.productInBasket.Add(new ProductListItemVM(productDb));
        }

        public void RemoveProductFromBasket(Guid ProductId)
        {
            var productDb = DB.Products.Find(ProductId);
            ShopBasket.productInBasket.Remove(new ProductListItemVM(productDb));
        }

        public void SendBasketToOrder()
        {
            throw new NotImplementedException();
        }

        public decimal GetBasketPrice()
        {
            decimal price = 0;
            foreach (var product in ShopBasket.productInBasket)
            {
                price += product.ProductPrice;
            }
            return price;
        }
    }
}
