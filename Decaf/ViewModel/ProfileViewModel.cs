using Decaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decaf.ViewModel
{
    public class ProfileViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Schedules Schedules { get; set; }
    }
}