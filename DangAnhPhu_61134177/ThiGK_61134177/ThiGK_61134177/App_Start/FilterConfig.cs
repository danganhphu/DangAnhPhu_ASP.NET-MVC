﻿using System.Web;
using System.Web.Mvc;

namespace ThiGK_61134177
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
