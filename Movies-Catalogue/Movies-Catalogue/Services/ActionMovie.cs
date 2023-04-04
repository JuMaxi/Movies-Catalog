using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;
using Movies_Catalogue.Interfacies;
using Movies_Catalogue.Interfaces;
using System.Data;
using System.Runtime.CompilerServices;

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

        public void NewMovie(MovieRequest New)
        {
            ValidateMo.Validate(New);
            ValidateMo.CheckDataIds(New);

            string Insert1 = "insert into Movies (Title, CoverImage, ReleaseDate, Rating, LengthM, Origin) values ('";

            Insert1 = Insert1 + New.Title + "','" + New.CoverImage + "','" + New.ReleaseDate.ToString("yyyy-MM-dd") +
                      "'," + New.Rating + "," + New.Length + ",'" + New.Origin + "')";

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

        private void AddBO(MovieRequest New, int LastId)
        {
            string Insert = "insert into BoxOffice (MovieId, Budget, RevenueOpeningWeek, RevenueWorldWide) values (" +
                LastId + "," + New.BoxOffice.Budget + "," + New.BoxOffice.RevenueOpeningWeek + "," + New.BoxOffice.RevenueWorldWide + ")";

            AccessDB.AccessNonQuery(Insert);
        }

        private void AddLocations(MovieRequest New, int LastId)
        {
            foreach (var Location in New.Locations)
            {
                string Insert = "insert into MovieLocations (MovieId, Location) values (" + LastId + ",'" + Location + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }

        private void AddActorRole(MovieRequest New, int LastId)
        {
            foreach (var Actor in New.MovieCast)
            {
                string Insert = "insert into MovieCast (MovieId, ActorId, Role) values (" + LastId + "," + Actor.ActorId + ",'" + Actor.Role + "')";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        private void RelationalMovieGender(MovieRequest New, int LastId)
        {
            foreach (var movieGender in New.MovieGender)
            {
                string Insert = "insert into RelationalMovieGender (MovieId, GenderId) values(" + LastId + "," + movieGender.Id + ")";

                AccessDB.AccessNonQuery(Insert);
            }
        }
        private void RelationalMovieProducer(MovieRequest New, int LastId)
        {
            foreach (var Producer in New.Producer)
            {
                string Insert = "insert into RelationalMovieProducer (MovieId, ProducerId) values(" + LastId + "," + Producer.Id + ")";

                AccessDB.AccessNonQuery(Insert);
            }
        }

        private string WriteSelect()
        {
            string Select = "SELECT Movies.Id, Movies.Title, Movies.CoverImage, Movies.ReleaseDate, Movies.Rating, Movies.LengthM, Movies.Origin, " +
                "MovieLocations.Location, " +
                "BoxOffice.Budget, BoxOffice.RevenueOpeningWeek, BoxOffice.RevenueWorldWide, " +
                "MovieCast.ActorId, Actors.Name, MovieCast.Role, " +
                "RelationalMovieGender.GenderId, Genders.Gender, " +
                "RelationalMovieProducer.ProducerId, Producer.Name as ProducerName " +
                "FROM Movies " +
                "INNER JOIN MovieLocations ON Movies.Id = MovieLocations.MovieId " +
                "INNER JOIN BoxOffice ON Movies.Id = BoxOffice.MovieId " +
                "INNER JOIN MovieCast ON Movies.Id = MovieCast.MovieId " +
                "INNER JOIN Actors ON MovieCast.ActorId = Actors.Id " +
                "INNER JOIN RelationalMovieGender ON Movies.Id = RelationalMovieGender.MovieId " +
                "INNER JOIN Genders ON RelationalMovieGender.GenderId = Genders.Id " +
                "INNER JOIN RelationalMovieProducer ON Movies.Id = RelationalMovieProducer.MovieId " +
                "INNER JOIN Producer ON RelationalMovieProducer.ProducerId = Producer.Id " +
                "WHERE Movies.Id = ";

            return Select;
        }

        private void ShowGeneralInfMovie(int IdCompare, MovieResponse Movie, IDataReader Reader)
        {
            if (IdCompare != Convert.ToInt32(Reader["Id"]))
            {
                Movie.Id = Convert.ToInt32(Reader["Id"]);
                Movie.Title = Reader["Title"].ToString();
                Movie.CoverImage = Reader["CoverImage"].ToString();
                Movie.ReleaseDate = Convert.ToDateTime(Reader["ReleaseDate"]).ToString("yyyy-MM-dd");
                Movie.Rating = Convert.ToDouble(Reader["Rating"]);
                Movie.Length = Convert.ToInt32(Reader["LengthM"]);
                Movie.Origin = Reader["Origin"].ToString();

                BoxOfficeResponse BoxOffice = new BoxOfficeResponse();
                BoxOffice.Budget = Convert.ToDouble(Reader["Budget"]);
                BoxOffice.RevenueOpeningWeek = Convert.ToDouble(Reader["RevenueOpeningWeek"]);
                BoxOffice.RevenueWorldWide = Convert.ToDouble(Reader["RevenueWorldWide"]);
                Movie.BoxOffice = BoxOffice;
            }
        }
        public MovieResponse ShowMovie(int Id)
        {
            int IdCompare = 0;

            string Select = WriteSelect() + Id;

            IDataReader Reader = AccessDB.AccessReader(Select);
            MovieResponse Movie = new MovieResponse();

            while (Reader.Read())
            {
                IdCompare = Movie.Id;
                ShowGeneralInfMovie(IdCompare, Movie, Reader);

                Movie.ShowFilmingLocation(Reader["Location"].ToString());
                Movie.ShowMovieCast(Convert.ToInt32(Reader["ActorId"]), Reader["Name"].ToString(), Reader["Role"].ToString());
                Movie.ShowMovieGender(Convert.ToInt32(Reader["GenderId"]), Reader["Gender"].ToString());
                Movie.ShowProducer(Convert.ToInt32(Reader["ProducerId"]), Reader["ProducerName"].ToString());
            }
            return Movie;
        }
        private List<int> ReturnListIds(int Page, int Size)
        {
            
            string SelectRow = "With Rows as " +
                "(select row_number() over (order by Id) as Row, Id from Movies)" +
                "select Id, Row from Rows where Row Between " + ((Size * Page) - (Size - 1)) + " and " + (Size * Page);

            IDataReader Reader = AccessDB.AccessReader(SelectRow);

            List<int> Ids = new List<int>();
            while (Reader.Read())
            {
                int Id = Convert.ToInt32(Reader["Id"]);
                Ids.Add(Id);
            }
            return Ids;
        }

        public List<MovieResponse> ShowListMovies(int Page, int Size)
        {
            if(Page == 0)
            {
                Page = 1;
            }
            if(Size == 0)
            {
                Size = 4;
            }

            List<int> ListIds = ReturnListIds(Page, Size);
            List<MovieResponse> ListMovies = new List<MovieResponse>();

            foreach (int Id in ListIds)
            {
                MovieResponse Movie = ShowMovie(Id);
                ListMovies.Add(Movie);
            }

            return ListMovies;
        }
    }

}

