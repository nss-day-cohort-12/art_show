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
                        join artist in _context.Artist
                        on work.ArtistId equals artist.ArtistId
                        group work by new
                        {
                          ArtWorkId = work.ArtWorkId,
                          Title = work.Title,
                          Image = piece.Image,
                          PurchaseURL = piece.PurchaseURL,
                          ArtistId = artist.ArtistId,
                          ArtistName = artist.Name,
                          Medium = work.Medium
                        } into artgroup
                        select new ArtWorkWithImagesViewModel
                        {
                          ArtWorkId = artgroup.Key.ArtWorkId,
                          Title = artgroup.Key.Title,
                          Image = artgroup.Key.Image,
                          PurchaseURL = artgroup.Key.PurchaseURL,
                          ArtistId = artgroup.Key.ArtistId,
                          ArtistName = artgroup.Key.ArtistName,
                          Medium = artgroup.Key.Medium
                        }).Distinct().ToList();
      return View(art);
    }

    public ActionResult IndividualPieceView(int ArtWorkId)
    {
      Context _context = new Context();
      ArtWorkWithImagesViewModel artPiece = (from work in _context.ArtWork
                         join piece in _context.IndividualPiece
                         on work.ArtWorkId equals piece.ArtWorkId
                         join artist in _context.Artist
                         on work.ArtistId equals artist.ArtistId
                         where work.ArtWorkId == ArtWorkId
                         select new ArtWorkWithImagesViewModel
                         {
                           ArtWorkId = work.ArtWorkId,
                           Title = work.Title,
                           Image = piece.Image,
                           PurchaseURL = piece.PurchaseURL,
                           Dimensions = work.Dimensions,
                           NumberInInventory = work.NumberInInventory,
                           Location = piece.Location,
                           Price = piece.Price,
                           ArtistId = artist.ArtistId,
                           ArtistName = artist.Name,
                           Medium = work.Medium
                         }).FirstOrDefault();
      /* image
       * price
       * dimensions
       * # in inventory
       * location
       */

      return View(artPiece);
    }

    public ActionResult IndividualArtistView(int ArtistId)
    {
      Context _context = new Context();
      ArtDetailViewModel art = new ArtDetailViewModel();
      art.ArtListings = (from work in _context.ArtWork
                         join artist in _context.Artist
                         on work.ArtistId equals artist.ArtistId
                         where work.ArtistId == ArtistId
                         join piece in _context.IndividualPiece
                         on work.ArtWorkId equals piece.ArtWorkId
                         select new ArtWorkWithImagesViewModel
                         {
                           ArtWorkId = work.ArtWorkId,
                           Title = work.Title,
                           Image = piece.Image,
                           PurchaseURL = piece.PurchaseURL,
                           ArtistName = artist.Name,
                           Medium = work.Medium
                         }).Distinct().ToList();
      return View(art);
    }

    public ActionResult IndividualMediumView(string MediumType)
    {
      Context _context = new Context();
      ArtDetailViewModel art = new ArtDetailViewModel();
      art.ArtListings = (from work in _context.ArtWork
                         join piece in _context.IndividualPiece
                         on work.ArtWorkId equals piece.ArtWorkId
                         join artist in _context.Artist
                         on work.ArtistId equals artist.ArtistId
                         where work.Medium == MediumType
                         select new ArtWorkWithImagesViewModel
                         {
                           ArtWorkId = work.ArtWorkId,
                           Title = work.Title,
                           Image = piece.Image,
                           PurchaseURL = piece.PurchaseURL,
                           ArtistName = artist.Name,
                           Medium = work.Medium,
                           ArtistId = artist.ArtistId
                         }).Distinct().ToList();
      return View(art);
    }
  }
}