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
        public List<MovieGender> GenderId { get; set; } 
        public Producer ProducerId { get; set; } 
    }
}
