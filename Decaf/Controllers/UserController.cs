using Decaf.Models;
using Decaf.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decaf.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var userInfo = _context.Users
                .Include(g => g.Gender)
                .Include(c => c.CivilStatus)
                .SingleOrDefault(u => u.UserID == id);
            if (userInfo == null)
                return HttpNotFound();

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

        public ActionResult BasicInformation(int id)
        {
            var userInfo = _context.Users
                .Include(g => g.Gender)
                .Include(c => c.CivilStatus)
                .SingleOrDefault(u => u.UserID == id);
            if (userInfo == null)
                return HttpNotFound();

            var viewModel = new RegisterViewModel
            {
                UserID = userInfo.UserID,
                FirstName = userInfo.FirstName,
                MiddleName = userInfo.MiddleName,
                LastName = userInfo.LastName,
                Username = userInfo.UserName,
                Email = userInfo.Email,
                BirthDate = userInfo.BirthDate,
                GenderId = userInfo.GenderId,
                CivilStatusId = userInfo.CivilStatusId,
                CivilStatus = _context.CivilStatuses.ToList(),
                Gender = _context.Genders.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBasicInformation(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            var userInfo = _context.Users
                .Include(g => g.Gender)
                .Include(c => c.CivilStatus)
                .SingleOrDefault(u => u.UserID == applicationUser.UserID);

            if (userInfo == null)
                return Content("No data"+ applicationUser.UserID);

            userInfo.FirstName = applicationUser.FirstName;
            userInfo.MiddleName = applicationUser.MiddleName;
            userInfo.LastName = applicationUser.LastName;
            userInfo.UserName = applicationUser.UserName;
            userInfo.Email = applicationUser.Email;
            userInfo.BirthDate = applicationUser.BirthDate;
            userInfo.GenderId = applicationUser.GenderId;
            userInfo.CivilStatusId = applicationUser.CivilStatusId;

            _context.SaveChanges();

            return RedirectToAction("Details/"+applicationUser.UserID, "User");
        }
    }
}