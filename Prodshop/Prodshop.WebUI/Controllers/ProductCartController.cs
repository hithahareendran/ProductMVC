﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodshop.WebUI.Controllers
{
    public class ProductCartController : Controller
    {
        // GET: ProductCart
        public ActionResult Index()
        {
            return View();
        }
    }
}