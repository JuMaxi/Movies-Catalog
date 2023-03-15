using Microsoft.AspNetCore.Mvc;
using Movies_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies_Catalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        AccessDB AccessDB = new AccessDB();

        [HttpPost]
        public void AddActor(Actor NewActor)
        {
            AddNewActor(NewActor);
        }

        public void AddNewActor(Actor NewActor)
        {
            string Insert = "insert into Actor (Name, Sex, PlaceOfBirth, DateOfBirth) values ('" + NewActor.Name + "','" + NewActor.Sex + "','" + NewActor.PlaceOfBirth + "','" + NewActor.DateOfBirth.ToString("yyyy-MM-dd") + "')";

            AccessDB.AccessNonQuery(Insert);
        }

    }
}
