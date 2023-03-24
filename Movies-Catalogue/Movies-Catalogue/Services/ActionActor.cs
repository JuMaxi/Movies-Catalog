using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;
using Movies_Catalogue.Validators;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public class ActionActor
    {
        AccessDB AccessDB = new AccessDB();
        ValidateActor ValidateActor = new ValidateActor();

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

            SqlDataReader Reader = AccessDB.AccessReader(Select);

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
    }
}
