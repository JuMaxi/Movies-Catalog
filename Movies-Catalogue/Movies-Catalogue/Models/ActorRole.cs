using Movies_Catalogue.Services;
using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class ActorRole
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public string Role { get; set; }
              
    }
}
