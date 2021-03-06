using ShopApp.BLL.ViewModels.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderVM createOrder, decimal totalPrice);
        //void ModifyOrder();
        void ChangeStatusOfOrder(Guid OrderId, string newStatus);
        List<OrderListItemVM> GetListOfOrders();
        List<OrderListItemVM> GetListOfOrdersByUser(Guid userId);

    }
}
