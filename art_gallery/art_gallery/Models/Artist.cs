using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace art_gallery.Models
{
  public class Artist
  {
    public int ArtistId { get; set; }
    public string Name { get; set; }
    public string BirthYear { get; set; }
    public string DeathYear { get; set; }
  }
}