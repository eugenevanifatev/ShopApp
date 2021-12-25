using ShopApp.BLL.Infrastructure;
using ShopApp.BLL.Intefaces;
using ShopApp.BLL.ViewModels.OrderVM;
using ShopApp.DAL;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        private AppDbContext DB { get; set; }
        public OrderService(AppDbContext _db)
        {
            DB = _db;
        }

        public void CreateOrder(CreateOrderVM createOrder, decimal totalPrice)
        {
            try
            {
                if (totalPrice == 0)
                {
                    throw new Exception("Shopping basket is empty");
                }
                var newOrder = new Order
                {
                    OrderAddress = createOrder.OrderAddress,
                    OrderPhone = createOrder.OrderPhone,
                    OrderPrice = totalPrice,
                    OrderStatus = 0,
                    UserId = CurrentAccount.Id
                };
                DB.Orders.Add(newOrder);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ChangeStatusOfOrder()
        {
            throw new NotImplementedException();
        }
    }
}
