using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbcSport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GbcSport.Controllers
{
    public class IncidentController : Controller
    {
        private CompanyContext context { get; set; }

        public IncidentController(CompanyContext ctx)
        {
            context = ctx;
        }


        public IActionResult IncidentPage()
        {

            var incident = context.Incidents
                .Include(c => c.Customer)
                .Include(c => c.Product);

            return View(incident);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(c => c.Firstname).ToList();
            ViewBag.Products = context.Products.OrderBy(c => c.Productname).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(c => c.Firstname).ToList();


            var customer = context.Incidents
                .Include(c => c.Technician)
                .Include(c => c.Product)
                .Include(c => c.Customer)
                .FirstOrDefault(c => c.IncidentId == id); 

            return View(customer);
        }


        
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            string action = (incident.IncidentId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                     incident.DateAdded = DateTime.Now;
                    context.Incidents.Add(incident);
                }
                else
                {
                    incident.DateAdded = DateTime.Now;
                    context.Incidents.Update(incident);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Customers = context.Customers.OrderBy(c => c.Firstname).ToList();
                ViewBag.Products = context.Products.OrderBy(c => c.Productname).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(c => c.Firstname).ToList();

                return View(incident);
            }


        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.Firstname).ToList();
            ViewBag.Products = context.Products.OrderBy(c => c.Productname).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(c => c.Firstname).ToList();
            return View("Edit", new Incident());
        }

        public IActionResult Delete(int id)
        {
            var incident = context.Incidents
                .Include(c => c.Customer)
                .Include(c => c.Technician)
                .Include(c => c.Product)
                .FirstOrDefault(c => c.IncidentId == id);

            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
