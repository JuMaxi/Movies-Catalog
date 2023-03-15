using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
