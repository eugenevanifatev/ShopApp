using ShopApp.BLL.Infrastructure;
using ShopApp.BLL.Intefaces;
using ShopApp.BLL.ViewModels.UserVM;
using ShopApp.DAL;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Services
{
    public class UserService : IUserService
    {
        private AppDbContext DB { get; set; }
        public UserService(AppDbContext _db)
        {
            DB = _db;
        }
        public bool LogIn(AccountVM accountVM)
        {
            try
            {
                var userDb = DB.Users.Single(m => m.Name == accountVM.Name && m.PasswordHash == accountVM.PasswrdHash);
                if (userDb == null)
                {
                    throw new Exception("Неверный логин или пароль");
                }
                CurrentAccount.Id = userDb.UserId;
                CurrentAccount.Name = userDb.Name;
                CurrentAccount.IsAdmin = userDb.IsAdmin;

                accountVM.IsAdmin = userDb.IsAdmin;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegisterUser(AccountVM accountVM)
        {
            try
            {
                if(DB.Users.Any(m=>m.Name==accountVM.Name))
                {
                    throw new Exception("Такой пользователь существует.");
                }
                var newUser = new User()
                {
                    Name = accountVM.Name,
                    PasswordHash = accountVM.PasswrdHash
                };
                DB.Users.Add(newUser);
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegisterAdmin(AccountVM accountVM)
        {
            try
            {
                if (DB.Users.Any(m => m.Name == accountVM.Name))
                {
                    throw new Exception("Такой пользователь существует.");
                }
                var newUser = new User()
                {
                    Name = accountVM.Name,
                    PasswordHash = accountVM.PasswrdHash,
                    IsAdmin = true
                };
                DB.Users.Add(newUser);
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
