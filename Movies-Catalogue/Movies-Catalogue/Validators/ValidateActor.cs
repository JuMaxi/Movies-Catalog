using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;

namespace Movies_Catalogue.Validators
{
    public interface IValidateActor
    {
        void Validate(Actor Actor);
    }
       
    public class ValidateActor : IValidateActor
    {
        public void Validate(Actor Actor)
        {
            string Name = Actor.Name.Trim();
            Actor.Name = Name;

            if (Name == null
                || Name.Length == 0
                || Name.IndexOf(" ") < 0)
            {
                throw new Exception("The actor's name + last name is mandatory. Fill this field to continue.");
            }
            if (Actor.Sex.Length == 0
                || Actor.Sex == null)
            {
                throw new Exception("The biological sex is mandatory. Choose, male or female to continue.");
            }
            if (Actor.PlaceOfBirth == null
                || Actor.PlaceOfBirth.Length == 0)
            {
                throw new Exception("The place of Birth is mandatory. Fill this field to continue.");
            }
            
            Movie ReleaseMovie= new Movie();
            DateTime FirstMovie = new DateTime(1895, 01, 01);
            if (Actor.DateOfBirth > DateTime.Now
                || Actor.DateOfBirth > ReleaseMovie.ReleaseDate
                || Actor.DateOfBirth.Year < FirstMovie.Year)

            {
                throw new Exception("The DateOfBirth is mandatory and can't be bigger than the date actual or the Date of the movie.");
            }

        }
    }
}
