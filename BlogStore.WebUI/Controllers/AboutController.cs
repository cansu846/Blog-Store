﻿using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
