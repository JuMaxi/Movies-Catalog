using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class Movie
    {
        public int Id { get; set; } // ok
        public string Title { get; set; } // ok
        public string CoverImage { get; set; } // ok 
        public DateTime ReleaseDate { get; set; } // ok 
        public double Rating { get; set; } // ok
        public int Length { get; set; } // ok
        public string Origin { get; set; } // ok
        public BoxOffice BoxOffice { get; set; } 
        public List<string> Locations { get; set; }    
        public List<MovieCast> MovieCast { get; set; } 
        public List<MovieGender> MovieGender { get; set; } 
        public Producer Producer { get; set; }

        public Movie()
        {
            Locations = new List<string>();
            MovieCast = new List<MovieCast>();
            MovieGender = new List<MovieGender>();
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

        public void ShowMovieCast(int Id, string Role)
        {
            MovieCast InsertRole = new MovieCast();
            for(int Position = 0; Position < MovieCast.Count; Position++)
            {
                if (MovieCast[Position].ActorId == Id)
                {
                    return;
                }
            }
            InsertRole.ActorId = Id;
            InsertRole.Role = Role;
            MovieCast.Add(InsertRole);
        }

        public void ShowMovieGender(int Id, string Gender)
        {
            MovieGender InsertGender = new MovieGender();

            for(int Position = 0; Position < MovieGender.Count; Position++)
            {
                if (MovieGender[Position].Id == Id)
                {
                    return;
                }
            }
            InsertGender.Id = Id;
            InsertGender.Gender = Gender;
            MovieGender.Add(InsertGender);
        }
    }
}
