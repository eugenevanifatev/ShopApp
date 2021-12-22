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
        public AdminMenu(AppDbContext _db) : base(_db) { }

        public void GetAdminMenuPage()
        {
            Console.WriteLine("Admin menu");
            Console.ReadKey();
        }
    }
}
