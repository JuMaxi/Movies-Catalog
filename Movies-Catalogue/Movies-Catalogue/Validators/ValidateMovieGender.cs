using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;

namespace Movies_Catalogue.Validators
{
    public interface IValidateMovieGender
    {
        void ValidateGender(MovieGender gender);
    }
    public class ValidateMovieGender : IValidateMovieGender
    {
        public void ValidateGender(MovieGender gender)
        {
            if (gender.Gender == null
                || gender.Gender.Length == 0)
            {
                throw new Exception("The field Gender can't be empty or null. Please fill the gender to continue.");
            }
        }
    }
}
