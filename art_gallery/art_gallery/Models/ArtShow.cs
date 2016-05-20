﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace art_gallery.Models
{
  public class ArtShow
  {
    public int ArtShowId { get; set; }
    public int ArtWorkId { get; set; }
    public string ShowLocation { get; set; }
    public string Agents { get; set; }
    public string Overhead { get; set; }
  }
}