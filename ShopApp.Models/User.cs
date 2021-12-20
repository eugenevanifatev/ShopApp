using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; } = false;
        public virtual List<Order> Orders { get; set; }
    }
}
