using EpiphanyMusic.Models;
using EpiphanyMusic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiphanyMusic.WebMvc.Controllers
{
    [Authorize]
    public class ConcertController : Controller
    {


        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConcertService(userId);
            var model = service.GetNotes();
            return View(model);
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcertCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateConcertService();

            if (service.CreateConcert(model))
            {
                TempData["SaveResult"] = "Concert has been created in Epiphany.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Concert could not be created in Epiphany.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateConcertService();
            var model = svc.GetConcertById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateConcertService();
            ConcertDetail detail = service.GetConcertById(id);
            var model =
                new ConcertEdit
                {
                    ConcertId = detail.ConcertId,
                    Artist = detail.Artist,
                    TourName = detail.TourName,
                    City = detail.City,
                    State = detail.State,
                    Price = detail.Price,
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateConcertService();
            var model = svc.GetConcertById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConcertEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConcertId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateConcertService();

            if (service.UpdateConcert(model))
            {
                TempData["SaveResult"] = "Your Concert Tour was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Concert Tour could not be updated.");
            return View(model);
        }

        private ConcertService CreateConcertService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConcertService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConcert(int id)


        {
            var service = CreateConcertService();

            service.DeleteConcert(id);

            TempData["SaveResult"] = "Your Concert Item was deleted";

            return RedirectToAction("Index");
        }
    }

}

