using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    public interface IShopBasketService
    {
        void AddProductToBasket(Guid ProductId);
        void RemoveProductFromBasket(Guid ProductId);
        void SendBasketToOrder();
        
    }
}
