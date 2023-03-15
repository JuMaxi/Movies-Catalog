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
        AddActor NewAc = new AddActor();

        [HttpPost]
        public void AddActor(Actor NewActor)
        {
            NewAc.AddNewActor(NewActor);
        }

        [HttpGet]
        public List<Actor> ShowActors()
        {
            List<Actor> ListActors = new List<Actor>();

            string Select = "select * from Actors";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while(Reader.Read())
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
    }
}
