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
                    OrderStatus = "formalized",
                    UserId = CurrentAccount.Id
                };

                foreach (var product in ShopBasket.productInBasket)
                {
                    var productDB = DB.Products.Find(product.ProductID);
                    newOrder.Products.Add(productDB);
                }

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

        public List<OrderListItemVM> GetListOfOrders()
        {
            var listOfOrders = new List<OrderListItemVM>();
            foreach (var order in DB.Orders)
            {
                listOfOrders.Add(new OrderListItemVM(order));
            }
            return listOfOrders;
        }
    }
}
