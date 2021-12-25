using ShopApp.Classes;
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
            GetStartPage();
        }

        static public void GetStartPage()
        {
            using (AppDbContext db = new AppDbContext())
            {
                //db.Users.Add(new Models.User() { Name = "admin", PasswordHash = "admin".GetHashCode().ToString(), IsAdmin = true });
                //db.SaveChanges();
                ConsoleHelper consoleHelper = new ConsoleHelper(db);
                consoleHelper.Start();
            }
        }
    }
}
