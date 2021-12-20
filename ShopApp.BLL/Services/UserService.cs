using ShopApp.BLL.Intefaces;
using ShopApp.BLL.ViewModels.UserVM;
using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Services
{
    public class UserService : IUserService
    {
        private AppDbContext Db { get; set; }
        public UserService(AppDbContext _db)
        {
            Db = _db;
        }
        public void LogIn(AccountVM accountVM)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(AccountVM accountVM)
        {
            try
            {
                //Db.Users.Any(m=>)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
