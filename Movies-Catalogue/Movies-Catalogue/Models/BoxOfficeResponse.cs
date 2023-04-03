using Movies_Catalogue.Services;
using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class BoxOfficeResponse
    {
        public double Budget { get; set; }
        public double RevenueOpeningWeek { get; set; }
        public double RevenueWorldWide { get; set; }

    }
}
