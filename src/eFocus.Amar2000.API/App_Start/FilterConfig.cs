﻿using System.Web;
using System.Web.Mvc;

namespace eFocus.Amar2000.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
