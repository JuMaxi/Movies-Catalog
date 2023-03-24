using Microsoft.AspNetCore.Mvc;
using Movies_Catalogue.Models;
using Movies_Catalogue.Services;
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
        ActionActor ActionActor = new ActionActor();

        [HttpPost]
        public void AddActor(Actor NewActor)
        {
            ActionActor.AddNewActor(NewActor);
        }

        [HttpGet]
        public List<Actor> ShowActors()
        {
            List<Actor> ListActors = new List<Actor>();
            ListActors = ActionActor.ShowActors();

            return ListActors;
        }

        [HttpPut]
        public void UpdateActor(Actor NewActor)
        {
            ActionActor.UpdateActor(NewActor);
        }
    }
}
