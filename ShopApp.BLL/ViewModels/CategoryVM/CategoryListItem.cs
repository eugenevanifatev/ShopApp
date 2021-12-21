using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.ViewModels.CategoryVM
{
    public class CategoryListItem
    {
        public CategoryListItem(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
        }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
