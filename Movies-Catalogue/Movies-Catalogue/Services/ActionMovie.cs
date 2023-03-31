using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;
using Movies_Catalogue.Interfacies;
using Movies_Catalogue.Interfaces;
using System.Data;

namespace Movies_Catalogue.Services
{
    public class ActionMovie : IActionMovie
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
        private int ReturnLastId()
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

        private void AddBO(Movie New, int LastId)
        {
            string Insert = "insert into BoxOffice (MovieId, Budget, RevenueOpeningWeek, RevenueWorldWide) values (" + LastId + "," + New.BoxOffice.Budget + "," + New.BoxOffice.RevenueOpeningWeek + "," + New.BoxOffice.RevenueWorldWide + ")";

            AccessDB.AccessNonQuery(Insert);
        }

        private void AddLocations(Movie New, int LastId)
        {
            foreach (var Location in New.Locations)
            {
                string Insert = "insert into MovieLocations (MovieId, Location) values (" + LastId + ",'" + Location + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }

        private void AddActorRole(Movie New, int LastId)
        {
            foreach (var Actor in New.MovieCast)
            {
                string Insert = "insert into MovieCast (MovieId, ActorId, Role) values (" + LastId + "," + Actor.ActorId + ",'" + Actor.Role + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        private void RelationalMovieGender(Movie New, int LastId)
        {
            foreach (var movieGender in New.GenderId)
            {
                string Insert = "insert into RelationalMovieGender (MovieId, GenderId) values(" + LastId + "," + movieGender.Id + ")";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        private void RelationalMovieProducer(Movie New, int LastId)
        {
            string Insert = "insert into RelationalMovieProducer (MovieId, ProducerId) values(" + LastId + "," + New.ProducerId.Id + ")";

            AccessDB.AccessNonQuery(Insert);
        }

        public Movie ShowMovie(int Id)
        {
            int IdCompare = 0;
            int ActorId = 0;
            int GenderId = 0;

            string Select = "SELECT Movies.Id, Movies.Title, Movies.CoverImage, Movies.ReleaseDate, Movies.Rating, Movies.LengthM, Movies.Origin, " +
                "MovieLocations.Location, " +
                "BoxOffice.Budget, BoxOffice.RevenueOpeningWeek, BoxOffice.RevenueWorldWide, " +
                "MovieCast.ActorId, Actors.Name, MovieCast.Role, " +
                "RelationalMovieGender.GenderId, Genders.Gender, " +
                "RelationalMovieProducer.ProducerId, Producer.Name " +
                "FROM Movies " +
                "INNER JOIN MovieLocations ON Movies.Id = MovieLocations.MovieId " +
                "INNER JOIN BoxOffice ON Movies.Id = BoxOffice.MovieId " +
                "INNER JOIN MovieCast ON Movies.Id = MovieCast.MovieId " +
                "INNER JOIN Actors ON MovieCast.ActorId = Actors.Id " +
                "INNER JOIN RelationalMovieGender ON Movies.Id = RelationalMovieGender.MovieId " +
                "INNER JOIN Genders ON RelationalMovieGender.GenderId = Genders.Id " +
                "INNER JOIN RelationalMovieProducer ON Movies.Id = RelationalMovieProducer.MovieId " +
                "INNER JOIN Producer ON RelationalMovieProducer.ProducerId = Producer.Id; ";

            IDataReader Reader = AccessDB.AccessReader(Select);
            Movie Movie = new Movie();

            while (Reader.Read())
            {
                List<string> ListLocations = new List<string>();
                BoxOffice BoxOffice = new BoxOffice();
                MovieCast MovieCast = new MovieCast();
                List<MovieCast> ListMovieCast = new List<MovieCast>();
                Actor Actors = new Actor();
                MovieGender Genders = new MovieGender();
                List<MovieGender> ListMovieGenders = new List<MovieGender>();
                Producer Producer = new Producer();

                int MovieId = Convert.ToInt32(Reader["Id"]);

                if (IdCompare != MovieId)
                {
                    Movie.Id = MovieId;
                    Movie.Title = Convert.ToString(Reader["Title"]);
                    Movie.CoverImage = Convert.ToString(Reader["CoverImage"]);
                    Movie.ReleaseDate = Convert.ToDateTime(Reader["ReleaseDate"]);
                    Movie.Rating = Convert.ToDouble(Reader["Rating"]);
                    Movie.Length = Convert.ToInt32(Reader["LengthM"]);
                    Movie.Origin = Convert.ToString(Reader["Origin"]);

                    ListLocations.Add(Convert.ToString(Reader["Location"]));
                    Movie.Locations = ListLocations;
                    
                    BoxOffice.Budget = Convert.ToDouble(Reader["Budget"]);
                    BoxOffice.RevenueOpeningWeek = Convert.ToDouble(Reader["RevenueOpeningWeek"]);
                    BoxOffice.RevenueWorldWide = Convert.ToDouble(Reader["RevenueWorldWide"]);
                    Movie.BoxOffice= BoxOffice;

                    ActorId = Convert.ToInt32(Reader["ActorId"]);
                    MovieCast.ActorId = ActorId;
                   // Actors.Name = Convert.ToString(Reader["Name"]);
                    MovieCast.Role = Convert.ToString(Reader["Role"]);
                    ListMovieCast.Add(MovieCast);
                    Movie.MovieCast = ListMovieCast;

                    GenderId = Convert.ToInt32(Reader["GenderId"]);
                    Genders.Id = GenderId;
                    Genders.Gender = Convert.ToString(Reader["Gender"]);
                    ListMovieGenders.Add(Genders);
                    Movie.GenderId = ListMovieGenders;

                    Producer.Id = Convert.ToInt32(Reader["ProducerId"]);
                    Producer.Name= Convert.ToString(Reader["Name"]);
                    Movie.ProducerId = Producer;

                    IdCompare = MovieId;
                }
                else
                {
                    Movie.Locations.Add(Convert.ToString(Reader["Location"]));

                    if (ActorId != Convert.ToInt32(Reader["ActorId"]))
                    {
                        ActorId = Convert.ToInt32(Reader["ActorId"]);
                        MovieCast.ActorId = ActorId;
                        //Actors.Name = Convert.ToString(Reader["Name"]);
                        MovieCast.Role = Convert.ToString(Reader["Role"]);
                        ListMovieCast.Add(MovieCast);
                        Movie.MovieCast.Add(ListMovieCast[0]);
                    }
                    if(GenderId != Convert.ToInt32(Reader["GenderId"]))
                    {
                        GenderId = Convert.ToInt32(Reader["GenderId"]);
                        Genders.Id = GenderId;
                        Genders.Gender = Convert.ToString(Reader["Gender"]);
                        ListMovieGenders.Add(Genders);
                        Movie.GenderId.Add(ListMovieGenders[0]);
                    }
                }
               
            }
            return Movie;
        }
    }

}

