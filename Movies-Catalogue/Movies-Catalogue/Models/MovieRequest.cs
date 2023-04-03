using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class MovieRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string CoverImage { get; set; } 
        public DateTime ReleaseDate { get; set; } 
        public double Rating { get; set; } 
        public int Length { get; set; } 
        public string Origin { get; set; } 
        public BoxOfficeRequest BoxOffice { get; set; } 
        public List<string> Locations { get; set; }    
        public List<MovieCastRequest> MovieCast { get; set; } 
        public List<MovieGenderRequest> MovieGender { get; set; } 
        public ProducerRequest Producer { get; set; }

    }
}
