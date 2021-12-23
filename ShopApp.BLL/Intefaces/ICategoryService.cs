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
        bool AddCategory(CreateCategoryVM categoryVM);
        List<CategoryListItemVM> GetListOfCategory();
        //void SelectCategory();

    }
}
