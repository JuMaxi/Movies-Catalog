using Movies_Catalogue.Services;
using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class BoxOffice
    {
        public int Id { get; set; }
        public double Budget { get; set; }
        public double RevenueOpeningWeek { get; set; }
        public double RevenueWorldWide { get; set; }

        AccessDB AccessDB = new AccessDB();
        public void AddBoxOffice(BoxOffice BoxOffice)
        {
            string Insert = "insert into BoxOffice (Budget, RevenueOpeningWeek, RevenueWorldWide) values (" + BoxOffice.Budget + "," + BoxOffice.RevenueOpeningWeek + "," + BoxOffice.RevenueWorldWide+ ")";

            AccessDB.AccessNonQuery(Insert);
        }
    }
}
