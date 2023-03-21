using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public class AddMovie
    {
        AccessDB AccessDB = new AccessDB();
        
        public void NewMovie (Movie New)
        {
            string Insert1 = "insert into Movies (Title, CoverImage, ReleaseDate, Rating, LengthM, Origin, Locations, ProducerId) values ('";
            Insert1 = Insert1 + New.Title + "','" + New.CoverImage + "','" + New.ReleaseDate.ToString("yyyy-MM-dd") + "'," + New.Rating + "," + New.Length + ",'" + New.Origin + "')";

            AccessDB.AccessNonQuery(Insert1);

            int LastId = ReturnLastId();

            AddBO(New, LastId);

            AddLocations(New, LastId);

            RelationalMovieGender(New, LastId);

            RelationalMovieProducer(New, LastId);
        }

        public int ReturnLastId()
        {
            int LastId = 0;
            string SelectLastId = "select MAX(Id) as last from Movies";

            SqlDataReader Reader = AccessDB.AccessReader(SelectLastId);

            while (Reader.Read())
            {
                LastId = Convert.ToInt32(Reader["Id"]);
            }

            return LastId;
        }

        public void AddBO(Movie New, int LastId)
        {
            string Insert = "insert into BoxOffice (MovieId, Budget, RevenueOpeningWeek, RevenueWorldWide) values (" + LastId + "," + New.BoxOffice.Budget.ToString("C2") + "," + New.BoxOffice.RevenueOpeningWeek.ToString("C2") + "," + New.BoxOffice.RevenueWorldWide.ToString("C2") + ")";

            AccessDB.AccessNonQuery(Insert);
        }

        public void AddLocations(Movie New, int LastId)
        {
            foreach (var Location in New.Locations)
            {
                string Insert = "insert into MovieLocations (MovieId, Location) values (" + LastId + ",'" + Location + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }

        public void AddActorRole(Movie New, int LastId)
        {
            foreach (var Actor in New.ActorRole)
            {
                string Insert = "insert into Castt (MovieId, ActorId, Role) values (" + LastId + "," + Actor.ActorId + ",'" + Actor.Role + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        public void RelationalMovieGender(Movie New, int LastId)
        {
            foreach(var movieGender in New.GenderId)
            {
                string Insert = "insert into RelationalMovieGender (MovieId, GenderId) values(" + LastId + "," + movieGender.Id + ")";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        public void RelationalMovieProducer(Movie New, int LastId)
        {
            string Insert = "inserto into RelationalMovieProducer (MovieId, ProducerId) values(" + LastId + New.ProducerId.Id + ")";

            AccessDB.AccessNonQuery(Insert);
        }
    }

}

