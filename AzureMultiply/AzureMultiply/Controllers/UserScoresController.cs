using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AzureMath.Entities;
using AzureMultiply.Models;

namespace AzureMultiply.Controllers
{   
    public class UserScoresController : Controller
    {
        private AzureMathDbContext context = new AzureMathDbContext();

        //
        // GET: /UserScores/

        public ViewResult Index()
        {
            return View(context.UserScores.Where(u=>u.User.UserName == User.Identity.Name).ToList());
        }

        //
        // GET: /UserScores/Details/5

        public ViewResult Details(int id)
        {
            UserScore userscore = context.UserScores.Single(x => x.UserScoreId == id);
            return View(userscore);
        }

        //
        // GET: /UserScores/Create

        public ActionResult Create()
        {
            ViewBag.PossibleUsers = context.Users;
            return View();
        } 

        //
        // POST: /UserScores/Create

        [HttpPost]
        public ActionResult Create(UserScore userscore)
        {
            if (ModelState.IsValid)
            {
                context.UserScores.Add(userscore);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleUsers = context.Users;
            return View(userscore);
        }
        
        //
        // GET: /UserScores/Edit/5
 
        public ActionResult Edit(int id)
        {
            UserScore userscore = context.UserScores.Single(x => x.UserScoreId == id);
            ViewBag.PossibleUsers = context.Users;
            return View(userscore);
        }

        //
        // POST: /UserScores/Edit/5

        [HttpPost]
        public ActionResult Edit(UserScore userscore)
        {
            if (ModelState.IsValid)
            {
                context.Entry(userscore).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleUsers = context.Users;
            return View(userscore);
        }

        //
        // GET: /UserScores/Delete/5
 
        public ActionResult Delete(int id)
        {
            UserScore userscore = context.UserScores.Single(x => x.UserScoreId == id);
            return View(userscore);
        }

        //
        // POST: /UserScores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserScore userscore = context.UserScores.Single(x => x.UserScoreId == id);
            context.UserScores.Remove(userscore);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}