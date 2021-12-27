using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.ViewModels.OrderVM
{
    public class OrderListItemVM
    {
        public OrderListItemVM(Order order)
        {
            OrderId = order.OrderId;
            OrderDate = order.OrderDate;
            OrderPrice = order.OrderPrice;
            OrderStatus = order.OrderStatus;
            OrderProducts = (List<Product>)order.Products;
        }

        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<Product> OrderProducts { get; set; }
        public int OrderIDNumber { get; set; }

        
    } 
}
