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

        //The id parameter will represent the page number
        public async Task<IActionResult> Index(int? id)
        {
            #region Comments
            //List<Product> products = ProductDb.GetProducts(context);

            //null coalescing operator, This is an alternative
            //int pageNum = id ?? 1;
            #endregion

            //Conditional/ternary operator; 
            int pageNum = (id.HasValue) ? id.Value : 1;
            const int PageSize = 3;

            List<Product> products = await ProductDb.GetProductsByPage(context, pageNum, PageSize);

            //ViewBag/ViewData
            //ViewBag.MaxPage = 2;
            int maxPage = ProductDb.GetMaxPage(context, PageSize);
            int currPage = pageNum;

            var model = new ProductIndexViewModel(products, maxPage, currPage);

            return View(model);
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

        public IActionResult Edit (int id)
        {
            //get the product by id
            Product p = ProductDb.GetProduct(context, id);

            //show it on web page
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                context.Update(p);
                context.SaveChanges();
                ViewData["Message"] = "Product Updated!";
                //Return same page with message, or redirect to another page
                return View(p);
            }
            //Return view with errors
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            Product p = ProductDb.GetProduct(context, id);
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //Get product from database
            Product p = ProductDb.GetProduct(context, id);

            //Mark the object as deleted
            context.Products.Remove(p);

            //Send delete query to database
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Search(SearchCriteria search)
        {
            search.Products = ProductDb.SearchProducts(context, search);

            return View(search);
        }
    }
}