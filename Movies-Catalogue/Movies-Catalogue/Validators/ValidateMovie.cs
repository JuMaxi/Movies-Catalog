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

        public List<int> SelectTypeList(Movie New, string TypeList)
        {
            List<int> ListId = new List<int>();
           
            if(TypeList == "ActorId")
            {
                foreach(var Position in New.MovieCast)
                {
                    ListId.Add(Position.Id);
                }
            }
            else
            {
                foreach (var Position in New.GenderId)
                {
                    ListId.Add(Position.Id);
                }
            }

            return ListId;
        }
        public string WriteSelect (List<int> ListId)
        {
            string SelectCount = "";

            for (int Position = 0; Position < ListId.Count; Position++)
            {
                if (Position != (ListId.Count - 1))
                {
                    SelectCount = SelectCount + ListId[Position] + ",";
                }
                else
                {
                    SelectCount = SelectCount + ListId[Position];
                }
            }
            return SelectCount;
        }

        public int ReturnId(List<int> ListId)
        {
            int Check = 0;
            string Select = WriteSelect(ListId);

            Select = "select from Actors WHERE ID IN(" + Select + ")";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                foreach (var Id in ListId)
                {
                    if (Id == Convert.ToInt32(Reader["Id"]))
                    {
                        Check = Check + 1;
                    }
                }
            }
            return Check;
        }
        public int ValidateActorId(Movie NewMovie)
        {
            string Type = "ActorId";

            List<int> List = SelectTypeList(NewMovie, Type);
            int Check = ReturnId(List);

            return Check;
        }

        public int ValidateProducerId(Producer Producer)
        {
            string Select = "select from Producer where Id=" + Producer.Id;

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                if(Producer.Id == Convert.ToInt32(Reader["Id"]))
                {
                    return Producer.Id;
                }
            }
            return 0;
        }

        public int ValidateGenderId(Movie NewMovie)
        {
            string Type = "GenderId";

            List<int> List = SelectTypeList(NewMovie, Type);
            int Check = ReturnId(List);

            return Check;
        }

    }
}
