using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;
using Movies_Catalogue.Interfaces;

namespace Movies_Catalogue.Validators
{
    public class ValidateProducer : IValidateProducer
    {
        public void Validate(Producer Producer)
        {
            if(Producer.Name == null
                || Producer.Name.Length == 0)
            {
                throw new Exception("The Producer's Name is mandatory. Fill out this field to continue.");
            }
            if(Producer.EstablishedDate > DateTime.Now)
            {
                throw new Exception("The Established Date must be smaller than the actual date.");
            }
            if(Producer.Place == null 
                || Producer.Place.Length == 0)
            {
                throw new Exception("The Producer's Place is mandatory. Fill out this field to continue.");
            }
        }
    }
}
