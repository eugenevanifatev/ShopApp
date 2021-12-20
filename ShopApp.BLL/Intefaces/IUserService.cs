using ShopApp.BLL.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    public interface IUserService
    {
        bool RegisterUser(AccountVM accountVM);
        bool LogIn(AccountVM accountVM);
        bool RegisterAdmin(AccountVM accountVM);
    }
}
