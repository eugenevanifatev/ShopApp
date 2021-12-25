using ShopApp.BLL.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    public interface ICategoryService
    {
        bool AddCategory(string categoryName);
        List<CategoryListItemVM> GetListOfCategory();
        void RemoveCategory(Guid categoryId);
        void EditCategory(Guid categoryId, string categoryName);

    }
}
