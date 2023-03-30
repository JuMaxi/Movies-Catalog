using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Movies_Catalogue.Models;
using Movies_Catalogue.Services;
using Movies_Catalogue.Interfacies;
using Movies_Catalogue.Interfaces;

namespace Movies_Catalogue.Validators
{
    public class ValidateMovie : IValidateMovie
    {
        IAccessDB AccessDB;

        public ValidateMovie(IAccessDB Access)
        {
            AccessDB = Access;
        }

        public void Validate(Movie NewMovie)
        {
            if (NewMovie.Title == null
                || NewMovie.Title.Length == 0)
            {
                throw new Exception("The Title is mandatory. Fill out this field to continue.");
            }
            if (NewMovie.CoverImage == null
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
            if (NewMovie.Length == 0)
            {
                throw new Exception("The Movie's Length is mandatory and must be bigger than zero. Fill out this field with a valid value to continue");
            }
            if (NewMovie.Origin == null
                || NewMovie.Origin.Length == 0)
            {
                throw new Exception("The Movie's Origin is mandatory. Fill out this field to continue.");
            }
        }

        private List<int> SelectTypeList(Movie New, string TypeList)
        {
            List<int> ListId = new List<int>();

            if (TypeList == "Actors")
            {
                foreach (var Position in New.MovieCast)
                {
                    ListId.Add(Position.ActorId);
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
        private string WriteSelect(List<int> ListId)
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

        private int ReturnCountListIds(List<int> ListId, string Type)
        {
            int Check = 0;
            string Select = WriteSelect(ListId);

            Select = "select * from " + Type + " WHERE ID IN(" + Select + ")";

            var Reader = AccessDB.AccessReader(Select);

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
        private int ValidateActorId(Movie NewMovie)
        {
            string Type = "Actors";

            List<int> List = SelectTypeList(NewMovie, Type);
            int Check = ReturnCountListIds(List, Type);

            return Check;
        }
        private int ValidateGenderId(Movie NewMovie)
        {
            string Type = "Genders";

            List<int> List = SelectTypeList(NewMovie, Type);
            int Check = ReturnCountListIds(List, Type);

            return Check;
        }

        private int ValidateProducerId(Producer Producer)
        {
            string Select = "select * from Producer where Id=" + Producer.Id;

            var Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                if (Producer.Id == Convert.ToInt32(Reader["Id"]))
                {
                    return Producer.Id;
                }
            }
            return 0;
        }

        public void CheckDataIds(Movie New)
        {
            int ActorId = ValidateActorId(New);
            int GenderId = ValidateGenderId(New);
            int ProducerId = ValidateProducerId(New.ProducerId);

            if (ActorId != New.MovieCast.Count)
            {
                throw new Exception("One or more ActorId is not valid. Fill out a valid Id do continue.");
            }
            else
            {
                if (GenderId != New.GenderId.Count)
                {
                    throw new Exception("One or more GenderId is not valid. Fill out a valid Id do continue.");
                }
                else
                {
                    if (ProducerId != New.ProducerId.Id)
                    {
                        throw new Exception("The Producer's Id is not valid. Fill out a valid Id do continue.");
                    }
                }
            }
        }
    }
}
