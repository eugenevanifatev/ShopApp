using ShopApp.BLL.Intefaces;
using ShopApp.BLL.Services;
using ShopApp.BLL.ViewModels.UserVM;
using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopApp.Classes
{
    public class ConsoleHelper
    {
        private protected IUserService userService;
        private protected ICategoryService categoryService;
        private protected IProductService productService;
        private protected IOrderService orderService;
        private protected IShopBasketService shopBasketService;

        private protected AppDbContext db;

        public ConsoleHelper(AppDbContext _db)
        {
            userService = new UserService(_db);
            categoryService = new CategoryService(_db);
            productService = new ProductService(_db);
            orderService = new OrderService(_db);
            shopBasketService = new ShopBasketService(_db);

            db = _db;
        }

        public void GetStartPage()
        {
            Console.Clear();
            Console.WriteLine("Shop");
            Console.WriteLine("Actions:");
            Console.WriteLine("1 - LogIn \n2 - Register \nEnter number: ");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    GetLogInPage();
                    break;
                case "2":
                    GetRegisterPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    GetStartPage();
                    break;
            }
        }

        private void GetLogInPage()
        {
            try
            {
                Console.Clear();
                var account = new AccountVM();

                Console.WriteLine("LogIn");

                Console.WriteLine("Enter Name:");
                account.Name = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                account.PasswordHash = Console.ReadLine().GetHashCode().ToString();

                var logInResult = userService.LogIn(account);

                if (account.IsAdmin == true)
                {
                    AdminMenu adminMenu = new AdminMenu(db);
                }
                else
                {
                    UserMenu userMenu = new UserMenu(db);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                Console.Clear();
                GetLogInPage();
            }
        }

        private void GetRegisterPage()
        {
            try
            {
                Console.Clear();
                var account = new AccountVM();

                Console.WriteLine("Registration");

                Console.WriteLine("Enter Name:");
                account.Name = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                account.PasswordHash = Console.ReadLine().GetHashCode().ToString();

                var registerResult = userService.RegisterUser(account);

                GetStartPage();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetLogInPage();
            }
                    
        }

    }
}
