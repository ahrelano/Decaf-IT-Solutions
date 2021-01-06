using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decaf.Models;
using Decaf.ViewModel;
using Microsoft.AspNet.Identity;

namespace Decaf.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class SchedulesController : Controller
    {
        private ApplicationDbContext _context;
        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var selectUser = _context.Users.SingleOrDefault(u => u.UserID == id);
            if (selectUser == null)
                return HttpNotFound();

            var EmployeeName = selectUser.FirstName + " " + selectUser.LastName;
            var userSched = _context.Schedules.SingleOrDefault(u => u.UserId == id);
            if (userSched == null)
            {
                var viewModel = new ScheduleFormViewModel
                {
                    Schedules = new Schedules(),
                    AspNetUsersId = id,
                    Name = EmployeeName
                };

                return View("ScheduleForm", viewModel);
            }
            else
            {
                var viewModel = new ScheduleFormViewModel
                {
                    Schedules = userSched,
                    AspNetUsersId = id,
                    Name = EmployeeName
                };
                return View("ScheduleForm", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Schedules schedules)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ScheduleFormViewModel
                {
                    Schedules = schedules,
                    AspNetUsersId = schedules.UserId
                  
                };

                return View("ScheduleForm", viewModel);
            }

            var userSchedule = _context.Schedules.SingleOrDefault(s => s.UserId == schedules.UserId);

            if (schedules.Id == 0 && userSchedule == null)
            {
                _context.Schedules.Add(schedules);
            }
            else
            {
                var scheduleInDb = _context.Schedules.Single(s => s.UserId == schedules.UserId);
                scheduleInDb.SunShiftFrom = schedules.SunShiftFrom;
                scheduleInDb.SunShiftTo = schedules.SunShiftTo;

                scheduleInDb.MonShiftFrom = schedules.MonShiftFrom;
                scheduleInDb.MonShiftTo = schedules.MonShiftTo;

                scheduleInDb.TueShiftFrom = schedules.TueShiftFrom;
                scheduleInDb.TueShiftTo = schedules.TueShiftTo;

                scheduleInDb.WedShiftFrom = schedules.WedShiftFrom;
                scheduleInDb.WedShiftTo = schedules.WedShiftTo;

                scheduleInDb.ThuShiftFrom = schedules.ThuShiftFrom;
                scheduleInDb.ThuShiftTo = schedules.ThuShiftTo;

                scheduleInDb.FriShiftFrom = schedules.FriShiftFrom;
                scheduleInDb.FriShiftTo = schedules.FriShiftTo;

                scheduleInDb.SatShiftFrom = schedules.SatShiftFrom;
                scheduleInDb.SatShiftTo = schedules.SatShiftTo;

                scheduleInDb.SunRestDay = schedules.SunRestDay;
                scheduleInDb.MonRestDay = schedules.MonRestDay;
                scheduleInDb.TueRestDay = schedules.TueRestDay;
                scheduleInDb.WedRestDay = schedules.WedRestDay;
                scheduleInDb.ThuRestDay = schedules.ThuRestDay;
                scheduleInDb.FriRestDay = schedules.FriRestDay;
                scheduleInDb.SatRestDay = schedules.SatRestDay;
            }
            _context.SaveChanges();

            return RedirectToAction("Details/"+ schedules.UserId, "User");
        }
    }
}