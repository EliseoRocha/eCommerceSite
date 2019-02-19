using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly CommerceContext _context;

        public CartController(CommerceContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            //Find product you want to add
            Product p = ProductDb.GetProduct(_context, id);

            //Turn product into JSON
            string data = JsonConvert.SerializeObject(p);

            CookieOptions options = new CookieOptions();
            options.Secure = true;
            options.MaxAge = TimeSpan.FromDays(365);

            //Store it in cookie
            HttpContext.Response.Cookies.Append("Cart", data, options);

            //Thank user and display product info
            return View(p);
        }
    }
}