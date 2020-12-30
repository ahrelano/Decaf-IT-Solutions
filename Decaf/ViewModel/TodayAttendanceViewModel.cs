using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Decaf.Models;

namespace Decaf.ViewModel
{
    public class TodayAttendanceViewModel
    {
        public System.TimeSpan? ShiftFrom { get; set; }
        public System.TimeSpan? ShiftTo { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public bool IsRestDay { get; set; }
    }
}