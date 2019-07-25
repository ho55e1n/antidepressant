using AntiDepressantWebApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AntiDepressantWebApplication.Controllers
{
    public class DiaryController : Controller
    {
        // GET: Diary
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                var diaryEntries = context.DiaryEntries
                    .Where(d => d.UserId == userId)
                    .OrderByDescending(d => d.Created);

                ViewBag.DiaryInput = diaryEntries.ToList();
            }


            return View("Diary");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddDiaryEntryViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("Diary", model);
            }

            var diaryEntries = new DiaryEntry
            {
                Id = Guid.NewGuid(),
                UserId = User.Identity.GetUserId(),
                Created = DateTime.Now,
                Text = model.Text
            };

            using (var context = new ApplicationDbContext())
            {
                context.DiaryEntries.Add(diaryEntries);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            using (var context = new ApplicationDbContext())
            {
                var diaryEntry = new DiaryEntry { Id = id };
                context.Entry(diaryEntry).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("diary/edit/:id")]
        public ActionResult Edit(Guid id, AddDiaryEntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new ApplicationDbContext())
            {
                var diary = context.DiaryEntries.SingleOrDefault(e => e.Id == id);
                diary.Text = model.Text;
                context.SaveChanges();
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }

}