using System.Collections.Generic;
using System;


namespace Movies_Catalogue.Models
{
    public class AddMGender
    {
        ValidateMovieGender ValidateMG = new ValidateMovieGender();
        AccessDB AccessDB = new AccessDB();

        public void AddNewGender(MovieGender NewGender)
        {
            ValidateMG.ValidateGender(NewGender);

            string Insert = "insert into Genders (Gender) values('" + NewGender.Gender + "')";
            AccessDB.AccessNonQuery(Insert);
        }
    }
}
