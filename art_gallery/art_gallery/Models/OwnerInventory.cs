using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace art_gallery.Models
{
    public class OwnerInventory
    {
        public int ArtWorkId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public int NumberInInventory { get; set; }
        public int NumberSold { get; set; }

        public int IndividualPieceId { get; set; }
        public string Image { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }

        public string Name { get; set; }
    }
}