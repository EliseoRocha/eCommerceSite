using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class ProductController : Controller
    {
        //Field
        //Read only means the constructor can modify the field but nothing else can
        private readonly CommerceContext context;

        //Constructor
        public ProductController(CommerceContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Product> products = ProductDb.GetProducts(context);
            return View(products);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                ProductDb.Add(p, context);
                ViewData["Message"] = $"{p.Name} was added!";
                return View();
            }

            //Show web page with errors
            return View(p);
        }
    }
}