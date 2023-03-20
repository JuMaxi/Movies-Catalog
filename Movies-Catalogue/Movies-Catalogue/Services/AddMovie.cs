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
            Insert1 = Insert1 + New.Title + "','" + New.CoverImage + "','" + New.ReleaseDate.ToString("yyyy-MM-dd") + "'," + New.Rating + "," + New.Length + ",'" + New.Origin + "','" + New.Locations + "','" + New.GenderId.Id + "," + New.ProducerId.Id + ")"; ;

            AccessDB.AccessNonQuery(Insert1);
        }
        
    }
}
