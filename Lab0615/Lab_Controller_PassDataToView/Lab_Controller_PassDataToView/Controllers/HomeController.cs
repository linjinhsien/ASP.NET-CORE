﻿using Lab_Controller_PassDataToView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Controller_PassDataToView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewData["welcome"] = "Fuck You!";
            //ViewBag.welcome = "Fuck You All";
            //string dataToModel = "Fuck You!!!";
            var emp = new Employee();
            emp.FirstName = "Lin";
            ViewData["data"] = emp.FirstName;
            return View();            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult First()
        {
            TempData["prompt"] = "資料已新增";
            return View();
        }
        public IActionResult Second()
        {
            //var prompt = TempData["prompt"] ?? "查無資料";
            var prompt = TempData.Peek("prompt") ?? "查無資料";
            return View(prompt);
        }
        public IActionResult Third()
        {
            var prompt = TempData["prompt"] ?? "查無資料";
            return View(prompt);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
