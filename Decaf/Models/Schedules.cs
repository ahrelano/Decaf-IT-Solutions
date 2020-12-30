using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Decaf.Models
{
    public class Schedules
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public TimeSpan? SunShiftFrom { get; set; }
        public TimeSpan? SunShiftTo { get; set; }

        public TimeSpan? MonShiftFrom { get; set; }
        public TimeSpan? MonShiftTo { get; set; }

        public TimeSpan? TueShiftFrom { get; set; }
        public TimeSpan? TueShiftTo { get; set; }

        public TimeSpan? WedShiftFrom { get; set; }
        public TimeSpan? WedShiftTo { get; set; }

        public TimeSpan? ThuShiftFrom { get; set; }
        public TimeSpan? ThuShiftTo { get; set; }

        public TimeSpan? FriShiftFrom { get; set; }
        public TimeSpan? FriShiftTo { get; set; }

        public TimeSpan? SatShiftFrom { get; set; }
        public TimeSpan? SatShiftTo { get; set; }

        public bool SunRestDay { get; set; }
        public bool MonRestDay { get; set; }
        public bool TueRestDay { get; set; }
        public bool WedRestDay { get; set; }
        public bool ThuRestDay { get; set; }
        public bool FriRestDay { get; set; }
        public bool SatRestDay { get; set; }
    }
}