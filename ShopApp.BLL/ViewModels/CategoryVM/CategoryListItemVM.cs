using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.ViewModels.CategoryVM
{
    public class CategoryListItemVM
    {
        public CategoryListItemVM(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
        }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryIdNumber { get; set; }
    }
}
