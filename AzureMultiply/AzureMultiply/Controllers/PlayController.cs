using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AzureMultiply.Models;

namespace AzureMultiply.Controllers
{
    public class PlayController : Controller
    {
        private const int MAX_VALUE = 20;
        
        //
        // GET: /Play/
        public ActionResult Index(SelectPlayModel selectedModel)
        {
            ViewBag.Message = "Play Azure Math!";
            ViewBag.HomeClass = "unselected";
            ViewBag.PlayClass = "selected";
            ViewBag.RegisterClass = "unselected";

            return View(selectedModel);
        }

        public ActionResult Select()
        {
            ViewBag.Message = "Select Play details";
            ViewBag.HomeClass = "unselected";
            ViewBag.PlayClass = "selected";
            ViewBag.RegisterClass = "unselected";
            return View();
        }

        public ActionResult PlayDirect()
        {
            ViewBag.Message = "Play Azure Math!";
            ViewBag.HomeClass = "unselected";
            ViewBag.PlayClass = "selected";
            ViewBag.RegisterClass = "unselected";

            return View();
        }

        [HttpPost]
        public ActionResult Select(SelectPlayModel model)
        {
            if (ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
                //return this.RedirectToAction(c => c.Index(model));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public ActionResult LoadPlay(string PlayMode, int Min, int Max)
        {
            SelectPlayModel playModel = new SelectPlayModel(String.Format("{0}|{1}|{2}", PlayMode, Min, Max));
            FullPlayModel fullModel = new FullPlayModel(playModel);

            return Json(fullModel.PlayValues);
        }


        public class MVal
        {
            public int Id { get; set; }
            public int Val { get; set; }
        }

        [HttpPost]
        public ActionResult LoadMaxValues(int minValue)
        {
            List<MVal> maxVals = new List<MVal>();

            for (int i = minValue; i <= MAX_VALUE; i++)
                maxVals.Add(new MVal() { Id = i, Val = i });

            return Json(maxVals);
        }


        [HttpPost]
        public ActionResult SaveScore(string PlayMode, int Min, int Max, int numRight, int numWrong, int seconds, int rank)
        {
            SelectPlayModel playModel = new SelectPlayModel(String.Format("{0}|{1}|{2}", PlayMode, Min, Max));
            FullPlayModel fullModel = new FullPlayModel(playModel);

            return Json(fullModel.PlayValues);
        }


        /*
         * 		
        public int UserScoreId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ScoreTime { get; set; }
        public string Mode   { get; set; }
        public int MinVal    { get; set; }
        public int MaxVal    { get; set; }
        public int NumRight  { get; set; }
        public int NumWrong  { get; set; }
        public int TimeSec   { get; set; }
        public int RankScore { get; set; }
         * 
         * */


        //[HttpPost]
        //public ActionResult LoadPlay(int minValue)
        //{
        //    SelectPlayModel playModel = new SelectPlayModel(String.Format("{0}|{1}|{2}", "Multiply", minValue, 10));
        //    FullPlayModel fullModel = new FullPlayModel(playModel);

        //    return Json(fullModel.PlayValues);
        //}

        ////
        //// GET: /Play/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Play/Create

        //public ActionResult Create()
        //{
        //    return View();
        //} 

        ////
        //// POST: /Play/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }


        //}

        //[HttpPost]
        //public ActionResult LoadPlay(object selectModel)
        //{
        //    return Json(selectModel);
        //}

        ////
        //// GET: /Play/Edit/5
        // public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Play/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Play/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Play/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
