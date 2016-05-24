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
                                  orderby ip.IndividualPieceId
                                  select new OwnerInventory
                                  {
                                      Title = aw.Title,
                                      Name = ar.Name,
                                      Cost = ip.Cost,
                                      Price = ip.Price,
                                      IndividualPieceId = ip.IndividualPieceId
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
        public ActionResult Edit(int ipId)
        {
            using (Context _context = new Context())
            {
                var ipDetails = (from ip in _context.IndividualPiece
                                 join aw in _context.ArtWork
                                 on ip.ArtWorkId equals aw.ArtWorkId
                                 join ar in _context.Artist
                                 on aw.ArtistId equals ar.ArtistId
                                 where ip.IndividualPieceId == ipId
                                 select new OwnerInventoryViewModel
                                 {
                                     Image = ip.Image,
                                     Cost = ip.Cost,
                                     Price = ip.Price,
                                     Sold = ip.Sold,
                                     Location = ip.Location,
                                     IndividualPieceId = ip.IndividualPieceId,
                                     EditionNumber = ip.EditionNumber,
                                     Name = ar.Name,
                                     Title = aw.Title,
                                     NumberInInventory = aw.NumberInInventory
                                 }).ToList();

                OwnerInventoryListViewModel ownerInventoryModel = new OwnerInventoryListViewModel
                {
                    Name = ipDetails.Select(a => a.Name).FirstOrDefault(),
                    Image = ipDetails.Select(a => a.Image).FirstOrDefault(),
                    Price = ipDetails.Select(a => a.Price).FirstOrDefault(),
                    Cost = ipDetails.Select(a => a.Cost).FirstOrDefault(),
                    IndividualPieceId = ipDetails.Select(a => a.IndividualPieceId).FirstOrDefault()
                };

                return View(ownerInventoryModel);
            }
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public ActionResult Edit( OwnerInventoryListViewModel ownerInvDetails )
        {
            {
                using (Context _context = new Context())
                {
                    var IndvP = _context.IndividualPiece.Find(ownerInvDetails.IndividualPieceId);
                    if (ModelState.IsValid)
                    {
                        IndvP.Price = ownerInvDetails.Price;
                        IndvP.Cost = ownerInvDetails.Cost;

                        _context.SaveChanges();
                    }

                    var Artist = _context.Artist.Find(ownerInvDetails.ArtistId);
                    if (ModelState.IsValid)
                    {


                        _context.SaveChanges();
                    }

                    var Artwork = _context.IndividualPiece.Find(ownerInvDetails.ArtWorkId);
                    if (ModelState.IsValid)
                    {

                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(ownerInvDetails);
                }
            }
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                using (Context _context = new Context())
                {
                    IndividualPiece idvP = _context.IndividualPiece.Find(id);

                    _context.IndividualPiece.Remove(idvP);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
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
