using System.Collections.Generic;
using System;
using Movies_Catalogue.Validators;
using Movies_Catalogue.Models;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public interface IActionMGender
    {
        void AddNewGender(MovieGender NewGender);
        List<MovieGender> ShowGender();
        void UpdateGender(MovieGender MovieGender);
        void DeleteGender(int Id);
    }
    public class ActionMGender : IActionMGender
    {
        IAccessDB AccessDB;
        IValidateMovieGender ValidateMG;
        
        public ActionMGender(IAccessDB Access, IValidateMovieGender Validate)
        {
            AccessDB = Access;
            ValidateMG = Validate;
        }

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

            var Reader = AccessDB.AccessReader(Select);

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

        private bool CheckRelationalTable(int Id)
        {
            bool Delete = true;

            string Select = "select * from RelationalMovieGender where GenderId=" + Id;

            var Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                int GenderId = Convert.ToInt32(Reader["GenderId"]);

                if(Id == GenderId)
                {
                    Delete = false;

                    int MovieId = Convert.ToInt32(Reader["MovieId"]);
                    throw new Exception("The Gender Id = " + GenderId + " is related with the Movie Id= " + MovieId + ". Before you continue this delete, you need to Update the GenderId about this Movie Id.");
                }
            }

            return Delete;
        }

        public void DeleteGender(int Id)
        {
            bool Delete = CheckRelationalTable(Id);

            if(Delete == true)
            {
                string DeleteG = "delete from Genders where Id=" + Id;

                AccessDB.AccessNonQuery(DeleteG);
            }
        }
       
    }
}
