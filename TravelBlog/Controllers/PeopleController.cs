using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PeopleController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        public IActionResult Index()
        {
            return View(db.Peoples.Include(peoples => peoples.Location).ToList());
            //return View(db.Peoples.Include(x => x.Experience).ThenInclude(x => x.Location).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPerson = db.Peoples.Include(x => x.Experience)
                                 .ThenInclude(x => x.Location)
                           .FirstOrDefault(peoples => peoples.PeopleId == id);
            return View(thisPerson);
        }
        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            ViewBag.ExperienceId  = new SelectList(db.Experiences, "ExperienceId", "Description");
            //ViewBag.ExperienceId = new SelectList(db.Experiences.Where(e => db.Experiences.LocationId == exp), "ExperienceId", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult Create(People people)
        {
            db.Peoples.Add(people);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            return View(thisPeople);
        }
        [HttpPost]
        public IActionResult Edit(People people)
        {
            db.Entry(people).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            return View(thisPeople);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            db.Peoples.Remove(thisPeople);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
            