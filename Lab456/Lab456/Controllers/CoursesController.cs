using Lab456.Models;
using Lab456.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab456.Controllers
{
    public class CoursesController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
               // GET: Courses
        public ActionResult Create()
        {
           
            var ViewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(ViewModel);
        }
        public ActionResult Create(CourseViewModel ViewModels)
        {
            if (!ModelState.IsValid)
            {
                ViewModels.Categories = _dbContext.Categories.ToList();
                return View("Create", ViewModels);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = ViewModels.GetDateTime(),
                CategoryId = ViewModels.Category,
                Place = ViewModels.Place
            };
            _dbContext.Courses.Add(course); 
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}