using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using art_gallery.Models;
using art_gallery.ViewModel;

namespace art_gallery.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index()
    {
      Context _context = new Context();
      ArtDetailViewModel art = new ArtDetailViewModel();
      art.ArtListings = (from work in _context.ArtWork
                        join piece in _context.IndividualPiece
                        on work.ArtWorkId equals piece.ArtWorkId
                        group work by new
                        {
                          ArtWorkId = work.ArtWorkId,
                          Title = work.Title,
                          Image = piece.Image,
                          PurchaseURL = piece.PurchaseURL
                        } into artgroup
                        select new ArtWorkWithImagesViewModel
                        {
                          ArtWorkId = artgroup.Key.ArtWorkId,
                          Title = artgroup.Key.Title,
                          Image = artgroup.Key.Image,
                          PurchaseURL = artgroup.Key.PurchaseURL
                        }).ToList();
      return View(art);
    }
  }
}