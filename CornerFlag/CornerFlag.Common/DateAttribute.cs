namespace CornerFlag.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateAttribute : RangeAttribute
    {
        public DateAttribute(int yearsFromTodayMinimum, int yearsFromTodayMaximum)
            : base(typeof(DateTime),
            DateTime.Now.AddYears(yearsFromTodayMinimum).ToShortDateString(),
            DateTime.Now.AddYears(yearsFromTodayMaximum).ToShortDateString()) 
        {             
        }
    }
}
