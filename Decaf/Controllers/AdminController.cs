using Decaf.Models;
using Decaf.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decaf.Controllers
{
    [Authorize (Roles = RoleName.Admin)]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var usersInfo = _context.Users
                .Include(g => g.Gender)
                .Include(c => c.CivilStatus)
                .ToList();
            return View(usersInfo);
        }
    }
}