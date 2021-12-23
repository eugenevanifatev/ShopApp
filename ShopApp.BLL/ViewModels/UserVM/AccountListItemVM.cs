using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.ViewModels.UserVM
{
    public class AccountListItemVM
    {
        public AccountListItemVM(User user)
        {
            UserID = user.UserId;
            Name = user.Name;
            IsAdmin = user.IsAdmin;
        }

        public Guid UserID { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
