using ShopApp.BLL.ViewModels.UserVM;
using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Classes
{
    public class StartMenu : ConsoleHelper
    {
        public StartMenu(AppDbContext _db) : base(_db)
        {
            GetStartPage();
        }

        public void GetStartPage()
        {
            Console.Clear();
            Console.WriteLine("Shop");
            Console.WriteLine("Actions:");
            Console.Write("1 - LogIn \n2 - Register \n3 - Close program \nEnter number: ");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    GetLogInPage();
                    break;
                case "2":
                    GetRegisterPage();
                    break;
                case"3":
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
                GetStartPage();
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
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetStartPage();
            }

        }
    }
}
