using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using art_gallery.Models;
using art_gallery.ViewModel;

namespace art_gallery.Controllers
{
    public class UpcomingEventsController : Controller
    {
        // GET: UpcomingEvent
        public ActionResult Index()
        {
            Context _context = new Context();
            UpcomingEventsViewModel eventList = new UpcomingEventsViewModel();
            eventList.UpcomingEvents = (from aw in _context.ArtWork
                                        join ar in _context.Artist
                                        on aw.ArtistId equals ar.ArtistId
                                        join ars in _context.ArtShow
                                        on aw.ArtWorkId equals ars.ArtWorkId
                                        select new Events
                                        {
                                            ShowName = ars.ShowName,
                                            ShowLocation = ars.ShowLocation,
                                            ShowDate = ars.ShowDate,
                                            Agents = ars.Agents,
                                            ArtistName = ar.Name

                                        }).ToList();
            return View(eventList);
            }
        }
    }
