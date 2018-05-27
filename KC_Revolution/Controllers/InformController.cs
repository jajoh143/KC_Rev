using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KC_Revolution.Data;
using KC_Revolution.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KC_Revolution.Controllers
{
    public class InformController : Controller
    {
        private RevolutionDbContext _context;

        public InformController(RevolutionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            var blogs = this._context.BlogPosts.ToList();
            return View(blogs);
        }

        public IActionResult WorshipSeries()
        {
            var sermons = new List<Sermon>();
            try
            {
                sermons = this._context.Sermons.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
            return View(sermons);
        }
    }
}