using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Classes
{
    internal class AdminMenu : ConsoleHelper
    {
        public AdminMenu(AppDbContext _db) : base(_db)
        {
            GetAdminMenuPage();
        }

        public void GetAdminMenuPage()
        {
            Console.Clear();
            Console.WriteLine("Admin menu");
            Console.WriteLine("Actions:");
            Console.WriteLine("1 - Create new Admin \n2 -  \nEnter number: ");
            Console.ReadKey();
        }
    }
}
