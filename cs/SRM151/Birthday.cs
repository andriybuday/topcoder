using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

public class Birthday
{
        public string getNext(string date, string[] birthdays)
        {
            var currentDate = convertToDate(date);

            var bDays = new List<DateTime>();
            foreach (var birthday in birthdays)
            {
                string bd = birthday.Split(' ')[0];
                DateTime dateTime = convertToDate(bd);
                if (dateTime < currentDate)
                {
                    dateTime = dateTime.AddYears(1);
                }
                bDays.Add(dateTime);
            }
            bDays.Sort();

            return bDays[0].ToString("MM/dd", CultureInfo.InvariantCulture);
        }

        public DateTime convertToDate(string d)
        {
            return DateTime.ParseExact(d + "/2000", "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }


}
//Powered by [KawigiEdit] 2.0!
