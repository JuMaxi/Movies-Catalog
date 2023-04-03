using System.Collections.Generic;
using System;

namespace Movies_Catalogue.Models
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string ReleaseDate { get; set; }

        public double Rating { get; set; }
        public int Length { get; set; }
        public string Origin { get; set; }
        public BoxOfficeResponse BoxOffice { get; set; }
        public List<string> Locations { get; set; }
        public List<MovieCastResponse> MovieCast { get; set; }
        public List<MovieGenderResponse> MovieGender { get; set; }
        public ProducerResponse Producer { get; set; }

        public MovieResponse()
        {
            Locations = new List<string>();
            MovieCast = new List<MovieCastResponse>();
            MovieGender = new List<MovieGenderResponse>();
        }

        public void ShowFilmingLocation(string Location)
        {
            for (int Position = 0; Position < Locations.Count; Position++)
            {
                if (Locations[Position] == Location)
                {
                    return;
                }
            }
            Locations.Add(Location);
        }

        public void ShowMovieCast(int Id, string Role, string ActorName)
        {
            MovieCastResponse InsertRole = new MovieCastResponse();
            for (int Position = 0; Position < MovieCast.Count; Position++)
            {
                if (MovieCast[Position].ActorId == Id)
                {
                    return;
                }
            }
            InsertRole.ActorId = Id;
            InsertRole.ActorName = ActorName;
            InsertRole.Role = Role;
            MovieCast.Add(InsertRole);
        }

        public void ShowMovieGender(int Id, string Gender)
        {
            MovieGenderResponse InsertGender = new MovieGenderResponse();

            for (int Position = 0; Position < MovieGender.Count; Position++)
            {
                if (MovieGender[Position].GenderId == Id)
                {
                    return;
                }
            }
            InsertGender.GenderId = Id;
            InsertGender.Gender = Gender;
            MovieGender.Add(InsertGender);
        }
    }
}
