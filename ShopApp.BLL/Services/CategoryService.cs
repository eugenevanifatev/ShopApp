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
        public bool AddCategory(CategoryVM category)
        {
            try
            {
                if(DB.Categories.Any(m=>m.CategoryName == category.Name))
                {
                    throw new Exception("Такая категория существует.");
                }
                DB.Categories.Add(new Models.Category { CategoryName = category.Name });
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<CategoryVM> ViewListOfCategory()
        {
            var listOfCategory = new List<CategoryVM>();
            foreach (var category in DB.Categories)
            {
                listOfCategory.Add(new CategoryVM() { Name = category.CategoryName});
            }
            return listOfCategory;
        }

        public void SelectCategory()
        {
            throw new NotImplementedException();
        }

       
    }
}
