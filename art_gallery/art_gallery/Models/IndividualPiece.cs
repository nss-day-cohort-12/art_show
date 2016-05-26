using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace art_gallery.Models
{
  public class IndividualPiece
  {
    public int IndividualPieceId { get; set; }
    public int ArtWorkId { get; set; }
    public string Image { get; set; }
    public string PurchaseURL { get; set; }
    public string DateCreated { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public string Location { get; set; }
    public string EditionNumber { get; set; }
    }
}