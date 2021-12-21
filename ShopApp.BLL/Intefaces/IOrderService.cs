using ShopApp.BLL.ViewModels.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    internal interface IOrderService
    {
        void CreateOrder(CreateOrderVM createOrder);
        //void ModifyOrder();
        void ChangeStatusOfOrder();

    }
}
