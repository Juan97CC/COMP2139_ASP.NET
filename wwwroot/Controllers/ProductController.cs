using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbcSport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GbcSport.Controllers
{
    public class ProductController : Controller
    {
        private CompanyContext context { get; set; }

        public ProductController(CompanyContext ctx) 
        {
            context = ctx;
        }

        public IActionResult ProductPage()
        {
            var products = context.Products
                .OrderBy(c => c.Productname).ToList();

            return View(products);
        }
       
        
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var products = context.Products
               
               .FirstOrDefault(c => c.ProductId == id);


            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                return View(product);
            }

        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products
                .FirstOrDefault(c => c.ProductId == id);


            return View(product);
        }

            [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("ProductPage", "Product");
        }

     





    }
}
