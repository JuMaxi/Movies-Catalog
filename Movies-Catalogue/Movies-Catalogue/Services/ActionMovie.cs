using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public class ActionMovie
    {
        IAccessDB AccessDB;
        IValidateMovie ValidateMo;

        public ActionMovie(IAccessDB Access, IValidateMovie Validate)
        {
            AccessDB = Access;
            ValidateMo = Validate;
        }

        public void NewMovie(Movie New)
        {
            ValidateMo.Validate(New);
            ValidateMo.CheckDataIds(New);

            string Insert1 = "insert into Movies (Title, CoverImage, ReleaseDate, Rating, LengthM, Origin) values ('";
            Insert1 = Insert1 + New.Title + "','" + New.CoverImage + "','" + New.ReleaseDate.ToString("yyyy-MM-dd") + "'," + New.Rating + "," + New.Length + ",'" + New.Origin + "')";

            AccessDB.AccessNonQuery(Insert1);

            int LastId = ReturnLastId();

            AddBO(New, LastId);

            AddLocations(New, LastId);

            AddActorRole(New, LastId);

            RelationalMovieGender(New, LastId);

            RelationalMovieProducer(New, LastId);

        }
        public int ReturnLastId()
        {
            int LastId = 0;
            string SelectLastId = "select MAX(Id) as last from Movies";

            var Reader = AccessDB.AccessReader(SelectLastId);

            while (Reader.Read())
            {
                LastId = Convert.ToInt32(Reader["last"]);
            }

            return LastId;
        }

        public void AddBO(Movie New, int LastId)
        {
            string Insert = "insert into BoxOffice (MovieId, Budget, RevenueOpeningWeek, RevenueWorldWide) values (" + LastId + "," + New.BoxOffice.Budget + "," + New.BoxOffice.RevenueOpeningWeek + "," + New.BoxOffice.RevenueWorldWide + ")";

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
            foreach (var Actor in New.MovieCast)
            {
                string Insert = "insert into MovieCast (MovieId, ActorId, Role) values (" + LastId + "," + Actor.ActorId + ",'" + Actor.Role + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        public void RelationalMovieGender(Movie New, int LastId)
        {
            foreach (var movieGender in New.GenderId)
            {
                string Insert = "insert into RelationalMovieGender (MovieId, GenderId) values(" + LastId + "," + movieGender.Id + ")";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        public void RelationalMovieProducer(Movie New, int LastId)
        {
            string Insert = "insert into RelationalMovieProducer (MovieId, ProducerId) values(" + LastId + "," + New.ProducerId.Id + ")";

            AccessDB.AccessNonQuery(Insert);
        }
    }

}

