using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext appDbContext = new AppDbContext();
            appDbContext.Users.Add(new Models.User() { Name = "admin", PasswordHash = "admin".GetHashCode().ToString(), IsAdmin = true });
            appDbContext.SaveChanges();
        }
    }
}
