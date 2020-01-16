using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typo.Logic.Services;
using Typo.Model.Models;

namespace Typo.Controllers
{
    public class ScoreController : Controller
    {
        private readonly ScoreService _ScoreServices;

        public ScoreController()
        {
            _ScoreServices = new ScoreService();
        }

        public ActionResult ScoreInput()
        {
            return View();
        }
        public ActionResult ScoreTake()
        {
            return View();
        }

        public ActionResult ScoreCreate()
        {
            return View();
        }

        public ActionResult ScoreAvg()
        {
            return View();
        }

        public ActionResult ScoreCurrent()
        {
            return View();
        }
        public ActionResult ScoreHigh()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ScoreInput(Score user)
        {
            _ScoreServices.ScoreInput(user.score, user.userId);

            return RedirectToAction("ScoreInput", "Score");
        }

        [HttpPost]
        public ActionResult ScoreCreate(Score user)
        {
            _ScoreServices.ScoreCreate(user.userId);

            return RedirectToAction("ScoreCreate", "Score");
        }

        [HttpPost]
        public ActionResult ScoreHigh(Score user)
        {
            var i = _ScoreServices.ScoreHigh(user.userId);
            string p = i.score;
            return Content(p);
        }

        [HttpPost]
        public ActionResult ScoreAvg(Score user)
        {
            var i = _ScoreServices.ScoreAvg(user.userId);
            string p = i.score;
            return Content(p);
        }

        [HttpPost]
        public ActionResult ScoreCurrent(Score user)
        {
            var i = _ScoreServices.ScoreCurrent(user.userId);
            string p = i.score;
            return Content(p);
        }
    }
}