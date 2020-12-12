using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_70_486.Models
{
    public class DateAndTime
    {
        public DateTime dateTime = DateTime.Now;
        public string ShortDate
        {
            get
            {
                return dateTime.ToLocalTime().ToShortDateString();
                //return dateTime.ToLocalTime().ToString();
            }
        }
    }
}