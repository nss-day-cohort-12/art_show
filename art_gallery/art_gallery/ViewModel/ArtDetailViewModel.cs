using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using art_gallery.Models;
using System.Web.Mvc;

namespace art_gallery.ViewModel
{
  public class ArtDetailViewModel
  {
    public List<ArtWorkWithImagesViewModel> ArtListings { get; set; }
    public List<decimal> priceFloor { get; set; }
    public List<decimal> priceCeiling { get; set; }
    public decimal[] priceRange { get; set; }
    public decimal selectedPriceFloor { get; set; }
    public decimal selectedPriceCeiling { get; set; }
    public SelectList priceOptions { get; set; }

    public ArtDetailViewModel()
    {
      priceFloor = new List<decimal>();
      priceCeiling = new List<decimal>();
    }
  }
}