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

        public void Start()
        {
            StartMenu startMenu = new StartMenu(db);
        }

    }
}
