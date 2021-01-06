using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Decaf.Models;

namespace Decaf.ViewModel
{
    public class ScheduleFormViewModel
    {
        public int AspNetUsersId { get; set; }
        public string Name { get; set; }
        public Schedules Schedules { get; set; }
    }
}