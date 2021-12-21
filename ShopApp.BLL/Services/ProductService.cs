using ShopApp.BLL.Intefaces;
using ShopApp.BLL.ViewModels.ProductVM;
using ShopApp.DAL;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Services
{
    internal class ProductService : IProductService
    {
        private AppDbContext DB { get; set; }
        public ProductService(AppDbContext _db)
        {
            DB = _db;
        }

        public bool AddProduct(CreateProductVM prod)
        {
            try
            {
                if (DB.Users.Any(m => m.Name == prod.ProductName))
                {
                    throw new Exception("Такой продукт существует.");
                }
                var newProduct = new Product()
                {
                    
                };
                DB.Products.Add(newProduct);
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddProductToOrder()
        {
            throw new NotImplementedException();
        }

        public List<ProductListItemVM> GetAllProductsByCategory(Guid categoryId)
        {
            var products = DB.Products.Where(m=>m.CategoryId == categoryId);
            var productList = new List<ProductListItemVM>();

            foreach (var product in products)
            {
                productList.Add(new ProductListItemVM(product));
            }
            return productList;
        }
    }
}
