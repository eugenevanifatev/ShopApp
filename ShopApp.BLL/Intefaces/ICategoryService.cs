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
        bool AddCategory(CategoryVM CategoryVM);
        List<CategoryVM> ViewListOfCategory();
        void SelectCategory();

    }
}
