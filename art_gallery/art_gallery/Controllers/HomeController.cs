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
      art.ArtListings = _context.ArtWork.ToList();
      return View(art);
    }
  }
}