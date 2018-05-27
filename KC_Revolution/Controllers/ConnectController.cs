using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KC_Revolution.Data;
using Microsoft.AspNetCore.Mvc;

namespace KC_Revolution.Controllers
{
    public class ConnectController : Controller
    {
        private RevolutionDbContext _context;

        public ConnectController(RevolutionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SmallGroups()
        {
            var smallGroups = _context.SmallGroups.ToList();
            return View(smallGroups);
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult RevKids()
        {
            return View();
        }
    }
}