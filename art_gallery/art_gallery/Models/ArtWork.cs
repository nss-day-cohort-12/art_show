﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace art_gallery.Models
{
  public class ArtWork
  {
    public int ArtWorkId { get; set; }
    public int ArtistId { get; set; }
    public string Title { get; set; }
    public string YearOriginalCreated { get; set; }
    public string Category { get; set; }
    public string Medium { get; set; }
    public string Dimensions { get; set; }
    public int NumberMade { get; set; }
    public int NumberInInventory { get; set; }
    public int NumberSold { get; set; }
  }
}