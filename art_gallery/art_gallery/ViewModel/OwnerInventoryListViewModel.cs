﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using art_gallery.Models;

namespace art_gallery.ViewModel
{
    public class OwnerInventoryListViewModel
    {
        //from artwork
        public int ArtWorkId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int NumberInInventory { get; set; }
        public int NumberSold { get; set; }

        //from individual piece
        public int IndividualPieceId { get; set; }
        public string Image { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }
        public string Location { get; set; }
        public string EditionNumber { get; set; }

        //from artist
        public string Name { get; set; }
        public string BirthYear { get; set; }

        public List<OwnerInventory> Inventory { get; set; }
    }
}