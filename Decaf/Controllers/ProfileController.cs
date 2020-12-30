using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decaf.Models;
using Decaf.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Decaf.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;
        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userInfo = _context.Users
                .Include(g => g.Gender)
                .Include(g => g.CivilStatus)
                .Single(u => u.Id == userId);
            var userSched = _context.Schedules.SingleOrDefault(u => u.UserId == userInfo.UserID);
            if (userSched == null)
                userSched = new Schedules();

            var viewModel = new ProfileViewModel
            {
                ApplicationUser = userInfo,
                Schedules = userSched
            };

            return View(viewModel);

            
        }
    }
}