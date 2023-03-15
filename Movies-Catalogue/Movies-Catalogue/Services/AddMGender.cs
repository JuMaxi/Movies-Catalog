using System.Collections.Generic;
using System;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;

namespace Movies_Catalogue.Services
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
