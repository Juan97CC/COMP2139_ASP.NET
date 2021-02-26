using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbcSport.Models;
using Microsoft.AspNetCore.Mvc;

namespace GbcSport.Controllers
{
    public class HomeController : Controller
    {
        private CompanyContext context { get; set; } 


        public HomeController(CompanyContext ctx)
        {
            context = ctx;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
