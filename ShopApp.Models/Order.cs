using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public decimal OrderPrice { get; set; }
        public int OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
