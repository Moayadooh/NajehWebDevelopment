﻿using System.Web;
using System.Web.Mvc;

namespace ASP_Identity_Individual_User_Accounts
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}