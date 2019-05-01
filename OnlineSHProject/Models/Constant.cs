using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSHProject.Models
{
    public enum UserRole
    {
        Admin = 0,
        ShopOwner = 1,
        Customer = 2,
    }

    public enum Category
    {
        Men = 0,
        Women = 1,
        Kids = 2,
        Accessories = 3,
        Food = 4,
    }

    public class Constant
    {
        public static List<SelectListItem> cataSelectList = new List<SelectListItem>() {
        new SelectListItem(){Text = "Men", Value = "0"},
        new SelectListItem(){Text = "Women", Value = "1"},
        new SelectListItem(){Text = "Kids", Value = "2"},
        new SelectListItem(){Text = "Accessories", Value = "3"},
        new SelectListItem(){Text = "Food", Value = "4"}};

        public static List<SelectListItem> RolesList = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Customer", Value = "2"},
            new SelectListItem() {Text = "ShopOwner", Value = "1"}
        };

    }
}