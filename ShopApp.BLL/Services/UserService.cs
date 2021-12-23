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
                var userDb = DB.Users.Single(m => m.Name == accountVM.Name && m.PasswordHash == accountVM.PasswordHash);
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
                    throw new Exception("Such a user exists.");
                }
                var newUser = new User()
                {
                    Name = accountVM.Name,
                    PasswordHash = accountVM.PasswordHash
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
                    throw new Exception("Such a admin exists.");
                }
                var newUser = new User()
                {
                    Name = accountVM.Name,
                    PasswordHash = accountVM.PasswordHash,
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

        public List<AccountListItemVM> GetListOFAccounts(bool isAdmin)
        {
            var usersFromDB = DB.Users.Where(m=>m.IsAdmin == isAdmin);
            var listOfUsers = new List<AccountListItemVM>();
            foreach (var user in usersFromDB)
            {
                listOfUsers.Add(new AccountListItemVM(user));
            }
            return listOfUsers;
        }

        public bool RemoveAccount(string userID)
        {
            try
            {
                var account = DB.Users.Find(new Guid(userID));
                if (account == null)
                    throw new Exception("Incorrect UserID");
                DB.Users.Remove(account);
                DB.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
