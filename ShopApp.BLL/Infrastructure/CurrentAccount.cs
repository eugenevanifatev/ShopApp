using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Infrastructure
{
    public static class CurrentAccount
    {
        public static Guid Id { get; set; }
        public static string Name { get; set; }
        public static bool IsAdmin { get; set; }
    }
}
