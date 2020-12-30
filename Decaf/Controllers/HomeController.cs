using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decaf.Models;
using Decaf.ViewModel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;

namespace Decaf.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult Index()
        {
            string userTimeIn = "00:00:00";
            string userTimeOut = "00:00:00";


            var userId = User.Identity.GetUserId();
            var userInfo = _context.Users.Single(u => u.Id == userId);
            var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            var userAttendanceInDb = _context.Attendances
                .SingleOrDefault(a => a.DateCreated == currentDate && a.UserId == userInfo.UserID);
            var userSchedule = _context.Schedules.SingleOrDefault(s => s.UserId == userInfo.UserID);

            //check if the user is already time in or not
            if (userAttendanceInDb == null)
            {
                ViewBag.WhichTime = "Time In";
            }
            else
            {
                ViewBag.WhichTime = "Time Out";
                if (userAttendanceInDb.TimeOut != null)
                {
                    ViewBag.WhichTime = "";
                }
            }

            var viewModel = new TodayAttendanceViewModel { };
            
            //Show user Time In and Time Out
            if (userAttendanceInDb != null && userAttendanceInDb.TimeIn.ToString() != "" && userAttendanceInDb.TimeOut.ToString() != "")
            {
                userTimeIn = userAttendanceInDb.TimeOut.ToString();
                userTimeOut = userAttendanceInDb.TimeOut.ToString();
            }
            else if (userAttendanceInDb != null && userAttendanceInDb.TimeIn.ToString() != "")
            {
                userTimeIn = userAttendanceInDb.TimeIn.ToString();
            }
            else if (userAttendanceInDb != null && userAttendanceInDb.TimeOut.ToString() != "")
            {
                userTimeOut = userAttendanceInDb.TimeOut.ToString();
            }

            //show user schedule for the day
            if (userSchedule != null)
            {
                if (DateTime.Now.DayOfWeek.ToString() == "Sunday")
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.SunShiftFrom,
                        ShiftTo = userSchedule.SunShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.SunRestDay
                    };
                }
                else if (DateTime.Now.DayOfWeek.ToString() == "Monday")
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.MonShiftFrom,
                        ShiftTo = userSchedule.MonShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.MonRestDay
                    };
                }
                else if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.TueShiftFrom,
                        ShiftTo = userSchedule.TueShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.TueRestDay
                    };

                }
                else if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.WedShiftFrom,
                        ShiftTo = userSchedule.WedShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.WedRestDay
                    };
                }
                else if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.ThuShiftFrom,
                        ShiftTo = userSchedule.ThuShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.ThuRestDay
                    };
                }
                else if (DateTime.Now.DayOfWeek.ToString() == "Friday")
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.FriShiftFrom,
                        ShiftTo = userSchedule.FriShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.FriRestDay
                    };
                }
                else
                {
                    viewModel = new TodayAttendanceViewModel
                    {
                        ShiftFrom = userSchedule.SatShiftFrom,
                        ShiftTo = userSchedule.SatShiftTo,
                        TimeIn = TimeSpan.Parse(userTimeIn),
                        TimeOut = TimeSpan.Parse(userTimeOut),
                        IsRestDay = userSchedule.SatRestDay
                    };
                }
            }


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save()
        {
            var userId = User.Identity.GetUserId();
            var userInfo = _context.Users.Single(u => u.Id == userId);
            var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            var userAttendanceInDb = _context.Attendances
                .SingleOrDefault(a => a.DateCreated == currentDate && a.UserId == userInfo.UserID);

            if (userAttendanceInDb == null)
            {
                var TimeIn = new Attendance();
                TimeIn.UserId = userInfo.UserID;
                TimeIn.TimeIn = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                TimeIn.DateCreated = currentDate;

                _context.Attendances.Add(TimeIn);
            }
            else
            {
                if (userAttendanceInDb.TimeOut != null)
                    return View("About");

                userAttendanceInDb.TimeOut = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}