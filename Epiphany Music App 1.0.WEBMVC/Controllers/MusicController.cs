using EpiphanyMusic.Data;
using EpiphanyMusic.Models;
using EpiphanyMusic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiphany_Music_App_1._0.WEBMVC.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayListService(userId);
            var model = service.GetNotes();

            return View(model);
        }
        //Add method here VVVV
        // GET
        public ActionResult Create()
        {
            return View();
        }
        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayListCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlayListService();

            if (service.CreatePlayList(model))
            {
                return RedirectToAction("Index");

                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "playlist could not be created.");


            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlayListService();
            var model = svc.GetPlayListById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlayListService();
            var detail = service.GetPlayListById(id);
            var model =
                new PlayListEdit
                {
                    PlayListId = detail.PlayListId,
                    Artist = detail.Artist,
                    Song = detail.Song,
                    Genre = detail.Genre,
                    Youtube = detail.Youtube,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayListEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlayListId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
                var service = CreatePlayListService();

            if (service.UpdatePlayList(model))
            {
                TempData["SaveResult"] = "Your PlayList was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your PlayList could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlayListService();
            var model = svc.GetPlayListById(id);

            return View(model);
        }
    

        private PlayListService CreatePlayListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayListService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlayList(int id)
        {
            var service = CreatePlayListService();

            service.DeletePlayList(id);

            TempData["SaveResult"] = "Your PlayList was deleted";

            return RedirectToAction("Index");
        }
    }
}
