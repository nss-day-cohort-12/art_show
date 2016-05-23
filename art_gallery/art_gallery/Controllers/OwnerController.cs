using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using art_gallery.Models;
using art_gallery.ViewModel;

namespace art_gallery.Controllers
{
    public class OwnerController : Controller
    {

        public List<OwnerInventory> OwnerInventory { get; set; }

        // GET: Owner
        public ActionResult Index()
        {
            Context _context = new Context();
            OwnerInventoryViewModel ownerInv = new OwnerInventoryViewModel();
            ownerInv.Inventory = (from aw in _context.ArtWork
                                  join ip in _context.IndividualPiece
                                  on aw.ArtWorkId equals ip.ArtWorkId
                                  join ar in _context.Artist
                                  on aw.ArtistId equals ar.ArtistId
                                  select new OwnerInventory
                                  {
                                      Title = aw.Title,
                                      Name = ar.Name,
                                      Cost = ip.Cost,
                                      Price = ip.Price,
                                  }).ToList();

            return View(ownerInv);
        }








        // GET: Owner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Owner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
