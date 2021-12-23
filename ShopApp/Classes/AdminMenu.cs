using ShopApp.BLL.ViewModels.UserVM;
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
            Console.WriteLine("1 - Create new Admin \n2 - Accounts \n3 - Categories \nEnter number: ");

            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    GetNewAdminPage();
                    break;
                case "2":
                    GetAccountsPage();
                    break;
                case "3":
                    GetCategoriesPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    Console.Clear();
                    GetAdminMenuPage();
                    break;
            }
        }

        private void GetAccountsPage()
        {
            Console.Clear();
            Console.WriteLine("Accounts");
            Console.WriteLine("Actions: \n1 - List of users \n2 - List of admins \n 3 - Back to main menu");

            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    GetListOfAccountsPage(false);
                    break;
                case "2":
                    GetListOfAccountsPage(true);
                    break;
                case "3":
                    GetAdminMenuPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    Console.Clear();
                    GetAccountsPage();
                    break;
            }
        }

        private void GetListOfAccountsPage(bool isAdmin)
        {
            Console.Clear();
            if(isAdmin == true)
                Console.WriteLine("List of admins:");
            else
                Console.WriteLine("List of users:");

            var listOfAccounts = userService.GetListOFAccounts(isAdmin);
            foreach (var account in listOfAccounts)
            {
                Console.WriteLine($"{account.UserID} -- {account.Name}");
            }

            Console.WriteLine("\n\nActions: \n1 - Remove Account \n2 - Back to main menu");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.Write("Enter UserID: ");
                    userService.RemoveAccount(Console.ReadLine());
                    GetListOfAccountsPage(isAdmin);
                    break;
                case "2":
                    GetAdminMenuPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    GetListOfAccountsPage(isAdmin);
                    break;
            }
        }

        private void GetCategoriesPage()
        {
            throw new NotImplementedException();
        }

        private void GetNewAdminPage()
        {
            try
            {
                Console.Clear();
                var account = new AccountVM();

                Console.WriteLine("Registration new Admin");

                Console.WriteLine("Enter Name:");
                account.Name = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                account.PasswordHash = Console.ReadLine().GetHashCode().ToString();

                var registerResult = userService.RegisterAdmin(account);

                GetAdminMenuPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                Console.Clear();
                GetAdminMenuPage();
            }
        }
    }
}
