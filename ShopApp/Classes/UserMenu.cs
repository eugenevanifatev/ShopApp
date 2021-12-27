using ShopApp.BLL.Infrastructure;
using ShopApp.BLL.ViewModels.OrderVM;
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
            Console.WriteLine($"Hello, {CurrentAccount.Name}!");
            Console.WriteLine("Actions:");
            Console.Write("1 - My account \n2 - Categories \n3 - Shopping Basket \n4 - Orders hsitory \n5 - Log Out\nEnter number: ");

            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    GetAccountPage();
                    break;
                case "2":
                    GetCategoriesPage();
                    break;
                case "3":
                    GetShopBasketPage();
                    break;
                case "4":
                    GetOrderHistoryPage();
                    break;
                case "5":
                    CurrentAccount.Id = Guid.Empty;
                    CurrentAccount.Name = null;
                    CurrentAccount.IsAdmin = false;
                    ShopBasket.productInBasket.Clear();
                    Program.GetStartPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    Console.Clear();
                    GetUserMenuPage();
                    break;
            }
        }

        private void GetOrderHistoryPage()
        {
            Console.Clear();
            Console.WriteLine("History of orders\n");
            var listOfOrders = orderService.GetListOfOrdersByUser(CurrentAccount.Id);
            int count = 0;
            foreach (var order in listOfOrders)
            {
                count++;
                Console.WriteLine($"{count}. {order.OrderDate.Day}.{order.OrderDate.Month}.{order.OrderDate.Year} {order.OrderDate.Hour}:{order.OrderDate.Minute} - Total Price: {order.OrderPrice}  Sttatus: {order.OrderStatus}");
                foreach (var product in order.OrderProducts)
                {
                    Console.Write($" {product.ProductName} ");
                }
                Console.WriteLine("\n--------------------------------");
                order.OrderIDNumber = count;
            }
            Console.WriteLine("\n\nActions: \n1 - Back to main menu");

            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    GetUserMenuPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    Console.Clear();
                    GetOrderHistoryPage();
                    break;
            }
        }

        private void GetShopBasketPage()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Your shopping basket:");
                int count = 0;
                decimal totalPrice = 0;
                foreach (var product in ShopBasket.productInBasket)
                {
                    count++;
                    Console.WriteLine($"{count}. {product.ProductName} - Price: {product.ProductPrice}$");
                    product.ProductIDNumber = count;
                    totalPrice += product.ProductPrice;
                }

                Console.Write($"\nTotal price: {totalPrice}$");

                Console.WriteLine("\n\nActions: \n1 - Remove product \n2 - Create order \n3 - Back to main menu");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        Console.Write("Enter number: ");
                        int numberOfProduct = Convert.ToInt32(Console.ReadLine());
                        var selectedProduct = ShopBasket.productInBasket.Single(c => c.ProductIDNumber == numberOfProduct);
                        productService.RemoveProduct(selectedProduct.ProductID);
                        GetShopBasketPage();
                        break;
                    case "2":
                        GetOrderCreatorPage(totalPrice);
                        GetShopBasketPage();
                        break;
                    case "3":
                        GetUserMenuPage();
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        Console.ReadKey();
                        GetShopBasketPage();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                GetShopBasketPage();
            }

        }

        private void GetOrderCreatorPage(decimal totalPrice)
        {
            try
            {
                CreateOrderVM order = new CreateOrderVM();

                Console.Write("\nEnter Address: ");
                order.OrderAddress = Console.ReadLine();

                Console.Write("Enter phone: ");
                order.OrderPhone = Console.ReadLine();

                orderService.CreateOrder(order, totalPrice);

                ShopBasket.productInBasket.Clear();
            }
            catch(Exception ex)
            {
                throw ex;
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
                Console.WriteLine("\n\nActions: \n1 - Select \n2 - Back to main menu");
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
                        GetUserMenuPage();
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
            Console.WriteLine("\n\nActions: \n1 - Select \n2 - Back to categories");
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
                    GetCategoriesPage();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    GetProdutsListPage(categoryId, categoryName);
                    break;
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

                Console.WriteLine("\n\nActions: \n1 - Add to shopping basket \n2 - Back to product list");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        shopBasketService.AddProductToBasket(productId);
                        GetProductPage(productId, categoryId, categoryName);
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

        private void GetAccountPage()
        {
            throw new NotImplementedException();
        }
    }
}
