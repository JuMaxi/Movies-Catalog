using System.Collections.Generic;
using System;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public class ActionMGender
    {
        ValidateMovieGender ValidateMG = new ValidateMovieGender();
        AccessDB AccessDB = new AccessDB();

        public void AddNewGender(MovieGender NewGender)
        {
            ValidateMG.ValidateGender(NewGender);

            string Insert = "insert into Genders (Gender) values('" + NewGender.Gender + "')";
            AccessDB.AccessNonQuery(Insert);
        }

        public List<MovieGender> ShowGender()
        {
            List<MovieGender> ListGender = new List<MovieGender>();

            string Select = "select * from Genders";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                MovieGender MovieGender = new MovieGender();

                MovieGender.Id = Convert.ToInt32(Reader["Id"]);
                MovieGender.Gender = Convert.ToString(Reader["Gender"]);

                ListGender.Add(MovieGender);
            }
            return ListGender;
        }
        public void UpdateGender(MovieGender MovieGender)
        {
            string Update = "update Genders set Gender= '" + MovieGender.Gender + "' where Id= " + MovieGender.Id;

            AccessDB.AccessNonQuery(Update);
        }

       
    }
}
