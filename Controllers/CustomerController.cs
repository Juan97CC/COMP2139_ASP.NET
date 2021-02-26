using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbcSport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GbcSport.Controllers
{
    public class CustomerController : Controller
    {
        private CompanyContext context { get; set; }

        public CustomerController(CompanyContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult CustomerPage()
        {
            var customer = context.Customers
                .Include(c => c.Country);
                

            return View(customer);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            
            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);

            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.CustomerId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                   // customer.DateAdded = DateTime.Now;
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
                return View(customer);
            }

        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



    }
}
