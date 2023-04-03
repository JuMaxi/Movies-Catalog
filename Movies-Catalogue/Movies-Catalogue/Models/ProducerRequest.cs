using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class ProducerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Place { get; set; }
        public int NumberEmployees { get; set; }
        public string Website { get; set; }
    }
}
