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

        [HttpPost]
        public ActionResult ScoreInput(Score user)
        {
            _ScoreServices.ScoreInput(user.score);

            return RedirectToAction("ScoreInput", "Score");
        }

<<<<<<< HEAD

        [HttpPost]
        public ActionResult ScoreCreate(Score user)
        {
            _ScoreServices.ScoreCreate(user.score);

            return RedirectToAction("ScoreCreate", "Score");
        }


=======
>>>>>>> develop
        [HttpPost]
        public ActionResult ScoreTake(Score user)
        {
            //var i =_ScoreServices.ScoreTake(user.userId);
            var i = _ScoreServices.ScoreAvg(user.userId);
            string p = i.score;
            return Content(p);
           // return RedirectToView ("ScoreTake", "Score");
        }

        [HttpPost]
        public ActionResult ScoreHigh(Score user)
        {
            _ScoreServices.ScoreHigh(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }

<<<<<<< HEAD




        /*
=======
>>>>>>> develop
        [HttpPost]
        public ActionResult ScoreAvg(Score user)
        {
            _ScoreServices.ScoreAvg(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }
<<<<<<< HEAD
        */




=======
>>>>>>> develop

        [HttpPost]
        public ActionResult ScoreCurrent(Score user)
        {
            _ScoreServices.ScoreCurrent(user.userId);

            return RedirectToAction("ScoreTake", "Score");
        }
    }
}