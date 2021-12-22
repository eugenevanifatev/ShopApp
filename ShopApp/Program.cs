﻿using ShopApp.Classes;
using ShopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                //db.Users.Add(new Models.User() { Name = "admin1", PasswordHash = "admin1".GetHashCode().ToString(), IsAdmin = true });
                //db.SaveChanges();
                ConsoleHelper consoleHelper = new ConsoleHelper(db);
                consoleHelper.GetStartPage();
            }
            
        }
    }
}
