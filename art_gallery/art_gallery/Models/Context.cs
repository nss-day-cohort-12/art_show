﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace art_gallery.Models
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(ar => ar.ArtistId);

            modelBuilder.Entity<Agent>()
                .ToTable("Agent")
                .HasKey(ag => ag.AgentId);

            modelBuilder.Entity<ArtShow>()
                .ToTable("ArtShow")
                .HasKey(ars => ars.ArtShowId);

            modelBuilder.Entity<ArtWork>()
                .ToTable("ArtWork")
                .HasKey(aw => aw.ArtWorkId);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<IndividualPiece>()
                .ToTable("IndividualPiece")
                .HasKey(ip => ip.IndividualPieceId);

            modelBuilder.Entity<Invoice>()
                .ToTable("Invoice")
                .HasKey(i => i.InvoiceId);

        }
    }
}