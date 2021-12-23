using ShopApp.BLL.Intefaces;
using ShopApp.BLL.ViewModels.CategoryVM;
using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private AppDbContext DB { get; set; }
        public CategoryService(AppDbContext _db)
        {
            DB = _db;
        }

        public bool AddCategory(string categoryName)
        {
            try
            {
                if(DB.Categories.Any(m=>m.CategoryName == categoryName))
                {
                    throw new Exception("Такая категория существует.");
                }
                DB.Categories.Add(new Models.Category { CategoryName = categoryName });
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public List<CategoryListItemVM> GetListOfCategory()
        {
            var listOfCategory = new List<CategoryListItemVM>();
            foreach (var category in DB.Categories)
            {
                listOfCategory.Add(new CategoryListItemVM(category));
            }
            return listOfCategory;
        }

        public void RemoveCategory()
        {
            throw new NotImplementedException();
        }
    }
}
