using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;

namespace Movies_Catalogue.Services
{
    public class AddMovie
    {
        AccessDB AccessDB = new AccessDB();
        public void NewMovie (Movie New)
        {
            string Insert1 = "insert into Movies (Title, CoverImage, ReleaseDate, Rating, LengthM, Origin, Locations) values ('";
            Insert1 = Insert1 + New.Title + "','" + New.CoverImage + "','" + New.ReleaseDate.ToString("yyyy-MM-dd") + "'," + New.Rating + ",'" + New.Length + "','" + New.Origin;

            string Divid = "','";
            for (int PositionLocations = 0; PositionLocations < New.Locations.Count; PositionLocations++)
            {
                string Temp = New.Locations[PositionLocations];
                Insert1 = Divid + Insert1 + Temp;
            }

            AccessDB.AccessNonQuery(Insert1 + ",)");
        }
    }
}
