using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;
using Movies_Catalogue.Interfacies;
using Movies_Catalogue.Interfaces;
using System.Data;
using System.Runtime.CompilerServices;
using System.Collections;

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
                "WHERE Movies.Id  ";

            return Select;
        }
        private string WriteSelecListMovies(int Page, int Size)
        {
            string Select = WriteSelect();

            if (Page == 0)
            {
                Page = 1;
            }
            if (Size == 0)
            {
                Size = 4;
            }

            string WhereIds = "IN (SELECT Id FROM Movies ORDER BY ID OFFSET " + ((Size * Page) - Size) + " ROWS FETCH NEXT " + Size + " ROWS ONLY)";
            Select = Select + WhereIds;

            return Select;
        }
        private bool CheckId(int IdCompare, IDataReader Reader)
        {
            if (IdCompare != Convert.ToInt32(Reader["Id"]))
            {
                return true;
            }
            return false;
        }
        private void ShowGeneralInfMovie(MovieResponse Movie, IDataReader Reader)
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

            CallMethods(Reader, Movie);
        }
        private void CallMethods(IDataReader Reader, MovieResponse Movie)
        {
            Movie.AddFilmingLocation(Reader["Location"].ToString());
            Movie.AddMovieCast(Convert.ToInt32(Reader["ActorId"]), Reader["Name"].ToString(), Reader["Role"].ToString());
            Movie.AddMovieGender(Convert.ToInt32(Reader["GenderId"]), Reader["Gender"].ToString());
            Movie.AddProducer(Convert.ToInt32(Reader["ProducerId"]), Reader["ProducerName"].ToString());
        }
        public MovieResponse ShowMovie(int Id)
        {
            string Select = WriteSelect() + " = " + Id;

            IDataReader Reader = AccessDB.AccessReader(Select);
            MovieResponse Movie = new MovieResponse();

            List<MovieResponse> MovieL = ReturnListMovies(Reader, Movie);

            return MovieL[0];
        }
       
        private List<MovieResponse> ReturnListMovies(IDataReader Reader, MovieResponse Movie)
        {
            int IdCompare = 0;

            List<MovieResponse> ListMovies = new List<MovieResponse>();

            while (Reader.Read())
            {
                IdCompare = Movie.Id;
                if (CheckId(IdCompare, Reader) == true)
                {
                    Movie = new MovieResponse();
                    ShowGeneralInfMovie(Movie, Reader);
                    ListMovies.Add(Movie);
                }
                else
                {
                    CallMethods(Reader, Movie);
                }
            }
            return ListMovies;
        }
      
        public List<MovieResponse> ShowListMovies(int Page, int Size)
        {
            string Select = WriteSelecListMovies(Page, Size);

            IDataReader Reader = AccessDB.AccessReader(Select);
            List<MovieResponse> ListMovies = new List<MovieResponse>();
            MovieResponse Movie = new MovieResponse();

            ListMovies = ReturnListMovies(Reader, Movie);

            return ListMovies;
        }
    }

}

