using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Decaf.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }

        [Required]
        public string DateCreated { get; set; }

        public int LateInMinutes { get; set; }
        public int UndertimeInMinutes { get; set; }



        public string ActionButton
        {
            get
            {
                return UserId != 0 ? "Time In" : "Time Out";
            }
        }
    } 
}