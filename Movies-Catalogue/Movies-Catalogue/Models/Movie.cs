using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public DateTime Length { get; set; }
        public BoxOffice BoxOffice { get; set; } // Id boxoffice
        public string Origin { get; set; }
        public string Locations { get; set; }    
        public List<ActorRole> ActorRole { get; set; } // id actor
        public List<MovieGender> GenderId { get; set; } // Id moviegender
        public Producer ProducerId { get; set; } // Id producer
    }
}
