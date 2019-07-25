using AntiDepressantWebApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AntiDepressantWebApplication.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                var exercises = context.Exercises
                    .Where(d => d.UserId == userId)
                    .OrderByDescending(d => d.Created);
                ViewBag.exercises = exercises.ToList();


                var geoLocation = context.Users.SingleOrDefault(e => e.Id == userId).GeoLocation;
                ViewBag.latitude = geoLocation.Split(',')[0];
                ViewBag.longitude = geoLocation.Split(',')[1];
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(AddExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                UserId = User.Identity.GetUserId(),
                Created = DateTime.Now,
                Location = model.Location
            };

            using (var context = new ApplicationDbContext())
            {
                context.Exercises.Add(exercise);
                context.SaveChanges();
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }


        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exercise = new Exercise
            {
                Id = id
            };


            using (var context = new ApplicationDbContext())
            {
                context.Entry(exercise).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }
    }


}