using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.ViewModels.UserVM
{
    public class AccountVM
    {
        public string Name { get; set; }
        public string PasswrdHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}
