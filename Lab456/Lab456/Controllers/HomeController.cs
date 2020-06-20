using Lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab456.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses
                 .Include(c => c.Lectuter)
                 .Include(c => c.Category)
                 .Where(c => c.DateTime > DateTime.Now);
            return View(upcommingCourses);
        }
    }
}
