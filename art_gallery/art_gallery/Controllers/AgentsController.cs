using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using art_gallery.Models;
using art_gallery.ViewModel;
using System.Data.Entity;

namespace art_gallery.Controllers
{
    public class AgentsController : Controller
    {
        // GET: Agents
        public ActionResult Index()
        {
            Context _context = new Context();
            var agentDetails = (from ag in _context.Agent
                                orderby ag.AgentId
                                select new AgentDetailViewModel
                                {
                                    AgentId = ag.AgentId,
                                    FirstName = ag.FirstName,
                                    LastName = ag.LastName,
                                    Address = ag.Address,
                                    Location = ag.Location,
                                    PhoneNumber = ag.PhoneNumber
                                }).ToList();

                return View(agentDetails);
        }


        // GET: Agents Details
        public ActionResult Details(int agentId)
        {
            Context _context = new Context();
            AgentListViewModel agentList = new AgentListViewModel();
            agentList.Agents = (from ag in _context.Agent
                                where ag.AgentId == agentId
                                join inv in _context.Invoice
                                on ag.AgentId equals inv.AgentId
                                join inp in _context.IndividualPiece
                                on inv.IndividualPieceId equals inp.IndividualPieceId
                                orderby ag.AgentId
                                select new AgentDetailViewModel
                                {
                                    AgentId = ag.AgentId,
                                    FirstName = ag.FirstName,
                                    LastName = ag.LastName,
                                    Location = ag.Location,
                                    Address = ag.Address,
                                    PhoneNumber = ag.PhoneNumber,
                                    Active = ag.Active,
                                    InvoiceId = inv.InvoiceId,
                                    IndividualPieceId = inp.IndividualPieceId,
                                    Cost = inp.Cost,
                                    Price = inp.Price,
                                    Profit = inp.Price - inp.Cost                              
                                }).ToList();

            return View(agentList);
        }

       
        // CREATE
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AgentDetailViewModel agentDetails)
        {
            using (Context _context = new Context())
            {
                if(ModelState.IsValid)
                {
                    Agent agent = new Agent
                    {
                        AgentId = agentDetails.AgentId,
                        FirstName = agentDetails.FirstName,
                        LastName = agentDetails.LastName,
                        Location = agentDetails.Location,
                        Address = agentDetails.Address,
                        PhoneNumber = agentDetails.PhoneNumber,
                        Active = agentDetails.Active
                    };
                    _context.Agent.Add(agent);

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(agentDetails);
        }

        // EDIT
        public ActionResult Edit(int agentId)
        {
            using (Context _context = new Context())
            {
                var agentDetails = (from ag in _context.Agent
                                    where ag.AgentId == agentId
                                    select new AgentDetailViewModel
                                    {
                                        FirstName = ag.FirstName,
                                        LastName = ag.LastName,
                                        Location = ag.Location,
                                        Address = ag.Address,
                                        PhoneNumber = ag.PhoneNumber,
                                        Active = ag.Active
                                    }).ToList();
                AgentDetailViewModel agentModel = new AgentDetailViewModel
                {
                    FirstName = agentDetails.Select(a => a.FirstName).FirstOrDefault(),
                    LastName = agentDetails.Select(a => a.LastName).FirstOrDefault(),
                    Location = agentDetails.Select(a => a.Location).FirstOrDefault(),
                    Address = agentDetails.Select(a => a.Address).FirstOrDefault(),
                    PhoneNumber = agentDetails.Select(a => a.PhoneNumber).FirstOrDefault(),
                    Active = agentDetails.Select(a => a.Active).FirstOrDefault()
                };
                return View(agentModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(AgentDetailViewModel agentDetails)
        {
            using (Context _context = new Context())
            {
                var agent = _context.Agent.Find(agentDetails.AgentId);
                if(ModelState.IsValid)
                {
                    agent.FirstName = agentDetails.FirstName;
                    agent.LastName = agentDetails.LastName;
                    agent.Location = agentDetails.Location;
                    agent.Address = agentDetails.Address;
                    agent.PhoneNumber = agentDetails.PhoneNumber;
                    agent.Active = agentDetails.Active;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(agentDetails);
            }

        }

        // DELETE
        public ActionResult Delete(int agentId)
        {
            if (agentId != 0)
                using (Context _context = new Context())
                {
                    Agent agent = _context.Agent.Find(agentId);

                    _context.Agent.Remove(agent);
                    _context.SaveChanges();
                }
            else
            {
                ViewBag.Title = "There was a problem";
            }
            return RedirectToAction("Index");
        }



        



    }
}