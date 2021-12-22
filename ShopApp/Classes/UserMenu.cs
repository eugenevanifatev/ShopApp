using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Classes
{
    public class UserMenu : ConsoleHelper
    {
        public UserMenu(AppDbContext _db) : base(_db)
        {
            GetUserMenuPage();
        }

        void GetUserMenuPage()
        {
            Console.Clear();
            Console.WriteLine("User menu");
            Console.ReadKey();
        }
    }
}
