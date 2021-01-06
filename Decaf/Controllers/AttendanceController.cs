using Decaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decaf.Controllers
{
    public class AttendanceController : Controller
    {
        private ApplicationDbContext _context;

        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Summary(DateTime from, DateTime to)
        {
            return View();
        }
    }
}