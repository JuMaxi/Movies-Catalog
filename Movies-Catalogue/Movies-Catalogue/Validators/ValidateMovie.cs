using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Movies_Catalogue.Models;
using Movies_Catalogue.Services;

namespace Movies_Catalogue.Validators
{
    
    public class ValidateMovie
    {
        AccessDB AccessDB = new AccessDB();
        public void Validate(Movie NewMovie)
        {
            if(NewMovie.Title == null
                || NewMovie.Title.Length == 0)
            {
                throw new Exception("The Title is mandatory. Fill out this field to continue.");
            }
            if(NewMovie.CoverImage == null
                || NewMovie.CoverImage.Length == 0)
            {
                throw new Exception("The Cover Image is mandatory. Fill out this field to continue.");
            }

            DateTime FirstMovie = new DateTime(1895, 01, 01);
            if (NewMovie.ReleaseDate.Year < FirstMovie.Year
                || NewMovie.ReleaseDate > DateTime.Now)
            {
                throw new Exception("The Release Date is invalid. Fill again this field with a valid date to continue.");
            }
            if(NewMovie.Length == 0)
            {
                throw new Exception("The Movie's Length is mandatory and must be bigger than zero. Fill out this field with a valid value to continue");
            }
            if(NewMovie.Origin == null
                || NewMovie.Origin.Length == 0)
            {
                throw new Exception("The Movie's Origin is mandatory. Fill out this field to continue.");
            }
        }

        public int ValidateActorId(List<ActorRole> List)
        {
            int Check = 0;
            string Select = "select * from Actors";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            for(int Position = 0; Position < List.Count; Position++)
            {
                int Id = List[Position].ActorId;

                while (Reader.Read())
                {
                    if(Id == Convert.ToInt32(Reader["Id"]))
                    {
                        Check = Check + 1;
                    }
                }
                
            }
            return Check;
        }

    }
}
