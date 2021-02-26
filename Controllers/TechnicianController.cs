using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbcSport.Models;
using Microsoft.AspNetCore.Mvc;

namespace GbcSport.Controllers
{
    public class TechnicianController : Controller
    {
        private CompanyContext context { get; set; }

        public TechnicianController(CompanyContext ctx)
        {
            context = ctx;
        }

        public IActionResult TechnicianPage()
        {
            var technician = context.Technicians
                .OrderBy(c => c.Firstname).ToList();

            return View(technician);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technicians = context.Technicians

               .FirstOrDefault(c => c.TechnicianId == id);


            return View(technicians);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {

                    context.Technicians.Add(technician);
                }
                else
                {
                    context.Technicians.Update(technician);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                return View(technician);
            }

        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Technician());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(c => c.TechnicianId == id);


            return View(technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }






    }
}
