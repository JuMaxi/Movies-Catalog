﻿using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public List<MovieGender> GenderList { get; set; } // Id moviegender
        public Producer Producer { get; set; } // Id producer
        public DateTime Length { get; set; }
        public BoxOffice BoxOffice { get; set; } // Id boxoffice
        public string Origin { get; set; }
        public List<string> Locations { get; set; }    
        public List<ActorRole> ActorRole { get; set; } // id actor
    }
}
