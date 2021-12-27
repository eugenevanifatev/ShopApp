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
using System.Data.Entity;

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

        public void ChangeStatusOfOrder(Guid OrderId, string newStatus)
        {
            try
            {
                var order = DB.Orders.Find(OrderId);
                if (order == null)
                    throw new Exception("There is no such order.");

                order.OrderStatus = newStatus;

                DB.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderListItemVM> GetListOfOrders()
        {
            var listOfOrders = new List<OrderListItemVM>();
            var a = DB.Orders.Include("");
            foreach (var order in DB.Orders)
            {
                //foreach (var product in DB.Orders.Include(m => m.Products))
                //{
                //    order.Products.Add(product);
                //}
                listOfOrders.Add(new OrderListItemVM(order) { UserName = DB.Users.Find(order.UserId).Name});
            }
            return listOfOrders;
        }

        public List<OrderListItemVM> GetListOfOrdersByUser(Guid userId)
        {
            var listOfOrders = new List<OrderListItemVM>();
            foreach (var order in DB.Orders.Where(m => m.UserId == userId))
            {
                listOfOrders.Add(new OrderListItemVM(order));
            }
            return listOfOrders;
        }
    }
}
