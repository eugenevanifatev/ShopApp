﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    public interface IProductService
    {
        void AddProduct();
        void ViewProduct();
        void AddProductToOrder();

    }
}