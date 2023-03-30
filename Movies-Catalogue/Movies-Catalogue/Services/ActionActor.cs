using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;
using Movies_Catalogue.Validators;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public class ActionActor
    {
        IAccessDB AccessDB;
        IValidateActor ValidateActor;

        public ActionActor(IAccessDB access, IValidateActor validate)
        {
            AccessDB = access;
            ValidateActor = validate;
        }

        public void AddNewActor(Actor NewActor)
        {
            ValidateActor.Validate(NewActor);

            string Insert = "insert into Actors (Name, Sex, PlaceOfBirth, DateOfBirth) values ('" + NewActor.Name + "','" + NewActor.Sex + "','" + NewActor.PlaceOfBirth + "','" + NewActor.DateOfBirth.ToString("yyyy-MM-dd") + "')";

            AccessDB.AccessNonQuery(Insert);
        }
        public List<Actor> ShowActors()
        {
            List<Actor> ListActors = new List<Actor>();

            string Select = "select * from Actors";

            var Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                Actor Actor = new Actor();

                Actor.Id = Convert.ToInt32(Reader["Id"]);
                Actor.Name = Convert.ToString(Reader["Name"]);
                Actor.Sex = Convert.ToString(Reader["Sex"]);
                Actor.PlaceOfBirth = Convert.ToString(Reader["PlaceOfBirth"]);
                Actor.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);

                ListActors.Add(Actor);
            }
            return ListActors;
        }
        public void UpdateActor(Actor Actor)
        {
            string Update = "update Actors set Name='" + Actor.Name + "', Sex='" + Actor.Sex + "', PlaceOfBirth='" + Actor.PlaceOfBirth + "', DateOfBirth='" + Actor.DateOfBirth.ToString("yyyy-MM-dd") + "' where Id=" + Actor.Id;

            AccessDB.AccessNonQuery(Update);
        }

        public bool CheckRelationalTable(int Id)
        {
            bool Delete = true;

            string Select = "select * from MovieCast where ActorId=" + Id;

            var Reader = AccessDB.AccessReader(Select);

            while(Reader.Read())
            {
                int ActorId = Convert.ToInt32(Reader["ActorId"]);

                if(Id == ActorId)
                {
                    Delete = false;

                    int MovieId = Convert.ToInt32(Reader["MovieId"]);
                    throw new Exception("The Actor Id = " + ActorId + " is related with the Movie Id = " + MovieId + ".Before you continue this delete, you need to Update the ActorId about this Movie Id.");
                }
            }
            return Delete;
        }

        public void DeleteActor(int Id)
        {
            bool Delete = CheckRelationalTable(Id);

            if(Delete == true)
            {
                string DeleteA = "delete from Actors where id=" + Id;

                AccessDB.AccessNonQuery(DeleteA);
            }
        }
    }
}
