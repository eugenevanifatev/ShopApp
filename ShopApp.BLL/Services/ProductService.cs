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
    public class ProductService : IProductService
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
                if (DB.Products.Any(m => m.ProductName == prod.ProductName))
                {
                    throw new Exception("Such a product exists.");
                }
                var newProduct = new Product()
                {
                    ProductName = prod.ProductName,
                    ProductPrice = prod.ProductPrice,
                    ProductDescription = prod.ProductDescription,
                    CategoryId = prod.CategoryId
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
            var products = DB.Products.Where(m => m.CategoryId == categoryId);
            var productList = new List<ProductListItemVM>();

            foreach (var product in products)
            {
                productList.Add(new ProductListItemVM(product));
            }
            return productList;
        }

        public CreateProductVM ViewProduct(Guid productId)
        {
            try
            {
                var product = DB.Products.Find(productId);
                CreateProductVM createProductVM = new CreateProductVM()
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductDescription = product.ProductDescription
                };
                return createProductVM;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EditProduct(Guid productId, CreateProductVM productVM)
        {
            try
            {
                var product = DB.Products.Find(productId);

                var result = DB.Products.FirstOrDefault(m => m.ProductName == productVM.ProductName);
                if(result!=null && result.ProductId != productId)
                {
                    throw new Exception("A product with the same name already exists.");
                }

                product.ProductName = productVM.ProductName;
                product.ProductPrice = productVM.ProductPrice;
                product.ProductDescription = productVM.ProductDescription;

                DB.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveProduct(Guid productId)
        {
            try
            {
                var product = DB.Products.Find(productId);
                if (product != null)
                {
                    DB.Products.Remove(product);
                    DB.SaveChanges();
                }
                else
                    throw new Exception("There is no such product.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
