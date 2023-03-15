using System.Collections.Generic;
using System;

namespace Movies_Catalogue.Models
{
    public class ValidateMovieGender
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
