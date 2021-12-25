using ShopApp.BLL.Infrastructure;
using ShopApp.BLL.ViewModels.CategoryVM;
using ShopApp.BLL.ViewModels.ProductVM;
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
            Console.WriteLine("1 - Create new Admin \n2 - Accounts \n3 - Categories \n4 - Log Out \nEnter number: ");

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
                case "4":
                    CurrentAccount.Id = Guid.Empty;
                    CurrentAccount.Name = null;
                    CurrentAccount.IsAdmin = false;
                    Program.GetStartPage();
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
            Console.WriteLine("Actions: \n1 - List of users \n2 - List of admins \n3 - Back to main menu");

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
            try
            {
                Console.Clear();
                Console.WriteLine("Categories:");
                var listOfCategories = categoryService.GetListOfCategory();
                int count = 0;
                foreach (var category in listOfCategories)
                {
                    count++;
                    Console.WriteLine($"{count}. {category.CategoryName}");
                    category.CategoryIdNumber = count;
                }
                Console.WriteLine("\n\nActions: \n1 - Select \n2 - Add \n3 - Edit \n4 - Remove \n5 - Back to main menu");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        Console.Write("Enter number: ");
                        int numberOfCategory = Convert.ToInt32(Console.ReadLine());
                        var selectedCategory = listOfCategories.Single(c => c.CategoryIdNumber == numberOfCategory);
                        GetProdutsListPage(selectedCategory.CategoryId, selectedCategory.CategoryName);
                        break;
                    case "2":
                        Console.Write("Enter name  of category: ");
                        categoryService.AddCategory(Console.ReadLine());
                        GetCategoriesPage();
                        break;
                    case "3":
                        Console.Write("Enter number: ");
                        numberOfCategory = Convert.ToInt32(Console.ReadLine());
                        selectedCategory = listOfCategories.Single(c => c.CategoryIdNumber == numberOfCategory);
                        Console.Write("Enter name  of category: ");
                        categoryService.EditCategory(selectedCategory.CategoryId, Console.ReadLine());
                        GetCategoriesPage();
                        break;
                    case "4":
                        Console.Write("Enter number: ");
                        numberOfCategory = Convert.ToInt32(Console.ReadLine());
                        selectedCategory = listOfCategories.Single(c => c.CategoryIdNumber == numberOfCategory);
                        categoryService.RemoveCategory(selectedCategory.CategoryId);
                        GetCategoriesPage();
                        break;
                    case "5":
                        GetAdminMenuPage();
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        Console.ReadKey();
                        GetCategoriesPage();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetCategoriesPage();
            }
        }

        private void GetProdutsListPage(Guid categoryId, string categoryName)
        {
            Console.Clear();
            Console.WriteLine($"{categoryName}:");
            var listOfProducts = productService.GetAllProductsByCategory(categoryId);
            int count = 0;
            foreach (var product in listOfProducts)
            {
                count++;
                Console.WriteLine($"{count}. {product.ProductName}");
                product.ProductIDNumber = count;
            }
            Console.WriteLine("\n\nActions: \n1 - Select \n2 - Add \n3 - Remove \n4 - Back to categories");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.Write("Enter number: ");
                    int numberOfProduct = Convert.ToInt32(Console.ReadLine());
                    var selectedproduct = listOfProducts.Single(c => c.ProductIDNumber == numberOfProduct);
                    GetProductPage(selectedproduct.ProductID, categoryId, categoryName);
                    break;
                case "2":
                    GetProductCreatorPage(categoryId, categoryName);
                    break;
                case "3":
                    Console.Write("Enter number: ");
                    numberOfProduct = Convert.ToInt32(Console.ReadLine());
                    selectedproduct = listOfProducts.Single(c => c.ProductIDNumber == numberOfProduct);
                    productService.RemoveProduct(selectedproduct.ProductID);
                    GetProdutsListPage(categoryId, categoryName);
                    break;
                case "4":
                    GetCategoriesPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    GetProdutsListPage(categoryId, categoryName);
                    break;
            }
        }

        private void GetProductCreatorPage(Guid categoryId, string categoryName)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("New Product\n");
                CreateProductVM createProductVM = new CreateProductVM();

                Console.Write("Name: ");
                createProductVM.ProductName = Console.ReadLine();

                Console.Write("Price: ");
                createProductVM.ProductPrice = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Description:");
                createProductVM.ProductDescription = Console.ReadLine();

                createProductVM.CategoryId = categoryId;

                productService.AddProduct(createProductVM);

                GetProdutsListPage(categoryId, categoryName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetProductCreatorPage(categoryId, categoryName);
            }
        }

        private void GetProductPage(Guid productId, Guid categoryId, string categoryName)
        {
            try
            {
                Console.Clear();
                var product = productService.ViewProduct(productId);
                Console.WriteLine($"{product.ProductName}\n");
                Console.WriteLine($"Price: {product.ProductPrice}$\n");
                Console.WriteLine($"Description:\n{product.ProductDescription}");

                Console.WriteLine("\n\nActions: \n1 - Edit \n2 - Back to product list");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        GetProductEditorPage(productId, categoryId, categoryName);
                        break;
                    case "2":
                        GetProdutsListPage(categoryId, categoryName);
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        Console.ReadKey();
                        GetProductPage(productId, categoryId, categoryName);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetCategoriesPage();
            }

        }

        private void GetProductEditorPage(Guid productId, Guid categoryId, string categoryName)
        {
            try
            {
                CreateProductVM createProductVM = new CreateProductVM();

                Console.Write("Name: ");
                createProductVM.ProductName = Console.ReadLine();

                Console.Write("Price: ");
                createProductVM.ProductPrice = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Description:");
                createProductVM.ProductDescription = Console.ReadLine();

                productService.EditProduct(productId, createProductVM);

                GetProductPage(productId, categoryId, categoryName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetProductEditorPage(productId, categoryId, categoryName);
            }
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
                GetAdminMenuPage();
            }
        }
    }
}
