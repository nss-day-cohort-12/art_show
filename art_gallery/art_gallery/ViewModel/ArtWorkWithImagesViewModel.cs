using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace art_gallery.ViewModel
{
  public class ArtWorkWithImagesViewModel
  {
    public int ArtWorkId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string PurchaseURL { get; set; }
  }
}