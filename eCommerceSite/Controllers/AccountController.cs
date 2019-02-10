using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly CommerceContext _context;

        public AccountController(CommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Member m)
        {
            if (ModelState.IsValid)
            {
                //Add to DB
                MemberDb.AddMember(m, _context);

                //Redirect to index page
                return RedirectToAction("Index", "Home");
            }
            //Returning the same View, with error messages
            return View(m);
        }

        public IActionResult Login()
        {
            //Session Test Code
            //HttpContext.Session.Set("Id", 1);

            return View();
        }
    }
}