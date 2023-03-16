using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;
using Movies_Catalogue.Validators;

namespace Movies_Catalogue.Services
{
    public class AddActor
    {
        AccessDB AccessDB = new AccessDB();
        ValidateActor ValidateActor = new ValidateActor();

        public void AddNewActor(Actor NewActor)
        {
            ValidateActor.Validate(NewActor);

            string Insert = "insert into Actors (Name, Sex, PlaceOfBirth, DateOfBirth) values ('" + NewActor.Name + "','" + NewActor.Sex + "','" + NewActor.PlaceOfBirth + "','" + NewActor.DateOfBirth.ToString("yyyy-MM-dd") + "')";

            AccessDB.AccessNonQuery(Insert);
        }
    }
}
