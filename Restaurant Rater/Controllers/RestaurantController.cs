﻿using Restaurant_Rater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Rater.Controllers
{
    public class RestaurantController : Controller
    {

        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = _db.Restaurants.Find(id);

            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant rest = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(rest);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}