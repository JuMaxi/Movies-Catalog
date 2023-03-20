using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;

namespace Movies_Catalogue.Services
{
    public class AddMovie
    {
        AccessDB AccessDB = new AccessDB();
        ActorRole ActorR = new ActorRole();

        public void NewMovie (Movie New)
        {
            string Insert1 = "insert into Movies (Title, CoverImage, ReleaseDate, Rating, LengthM, Origin, Locations, GenderId, ProducerId) values ('";
            Insert1 = Insert1 + New.Title + "','" + New.CoverImage + "','" + New.ReleaseDate.ToString("yyyy-MM-dd") + "'," + New.Rating + ",'" + New.Length.ToString("m") + "','" + New.Origin + "','" + New.Locations;

            for(int PositionGender = 0; PositionGender < New.GenderId.Count; PositionGender++)
            {
                string Temp = "," + Convert.ToString(New.GenderId[PositionGender].Id);
                Insert1 = Insert1 + Temp;
            }

            Insert1 = Insert1 + New.ProducerId.Id + ",)";

            AccessDB.AccessNonQuery(Insert1);
        }
        
    }
}
