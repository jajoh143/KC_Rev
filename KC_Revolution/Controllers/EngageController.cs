using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KC_Revolution.Controllers
{
    public class EngageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }
    }
}