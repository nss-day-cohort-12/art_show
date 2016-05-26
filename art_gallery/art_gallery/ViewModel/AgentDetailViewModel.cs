using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using art_gallery.Models;

namespace art_gallery.ViewModel
{
    public class AgentDetailViewModel
    {
        // from agent
        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }

        //from invoice
        public int IndividualPieceId { get; set; }

        //from individualPiece
        public decimal Cost { get; set; }
        public decimal Price { get; set; }


        public decimal Profit { get; set; }

        public List<Agent> Agent { get; set; }
    }
}