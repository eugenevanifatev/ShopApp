﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BLL.Intefaces
{
    internal interface IOrderService
    {
        void AddOrder();
        void ModifyOrder();
        void ChangeStatusOfOrder();

    }
}