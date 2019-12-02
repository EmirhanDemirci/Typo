﻿using System;
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

        [HttpPost]
        public ActionResult ScoreInput(Score user)
        {
            _ScoreServices.ScoreInput(user.score);

            return RedirectToAction("ScoreInput", "Score");
        }

        [HttpPost]
        public ActionResult ScoreTake(Score user)
        {
            _ScoreServices.ScoreTake(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }

        [HttpPost]
        public ActionResult ScoreHigh(Score user)
        {
            _ScoreServices.ScoreHigh(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }

        [HttpPost]
        public ActionResult ScoreAvg(Score user)
        {
            _ScoreServices.ScoreAvg(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }

        [HttpPost]
        public ActionResult ScoreCurrent(Score user)
        {
            _ScoreServices.ScoreCurrent(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }
    }
}