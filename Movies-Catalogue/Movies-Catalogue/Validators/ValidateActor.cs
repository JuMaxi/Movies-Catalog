using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;
using Movies_Catalogue.Interfaces;

namespace Movies_Catalogue.Validators
{
    public class ValidateActor : IValidateActor
    {
        public void Validate(Actor Actor)
        {
            string Name = Actor.Name;
            if(Actor.Name != null && Actor.Name.Length > 0)
            {
                Name = Actor.Name.Trim();
                Actor.Name = Name;
            }
            if (Name == null
                || Name.Length == 0
                || Name.IndexOf(" ") < 0)
            {
                throw new Exception("The actor's name + last name is mandatory. Fill this field to continue.");
            }
            if (Actor.Sex == null
                || Actor.Sex.Length == 0)
            {
                throw new Exception("The biological sex is mandatory. Choose, male or female to continue.");
            }
            if (Actor.PlaceOfBirth == null
                || Actor.PlaceOfBirth.Length == 0)
            {
                throw new Exception("The place of Birth is mandatory. Fill this field to continue.");
            }
            
            MovieRequest ReleaseMovie= new MovieRequest();
            if (Actor.DateOfBirth > DateTime.Now
                || Actor.DateOfBirth > ReleaseMovie.ReleaseDate)
            {
                throw new Exception("The DateOfBirth is mandatory and can't be bigger than the date actual or the Date of the movie.");
            }

        }
    }
}
