using Decaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decaf.ViewModel
{
    public class UpdateBasicInformationViewModel
    {
        public ApplicationUser ApplicationUser { get; set; } 
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<CivilStatus> CivilStatus { get; set; }
    }
}