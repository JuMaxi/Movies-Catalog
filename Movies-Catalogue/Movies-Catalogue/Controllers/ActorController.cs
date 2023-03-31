using Microsoft.AspNetCore.Mvc;
using Movies_Catalogue.Models;
using Movies_Catalogue.Services;
using System.Collections.Generic;
using Movies_Catalogue.Interfaces;

namespace Movies_Catalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        IActionActor ActionActor;

        public ActorController(IActionActor actionActor)
        {
            ActionActor = actionActor;
        }

        [HttpPost]
        public void AddActor(Actor NewActor)
        {
            ActionActor.NewActor(NewActor);
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

        [HttpDelete]
        public void DeleteActor([FromQuery] int Id)
        {
            ActionActor.DeleteActor(Id);
        }
    }
}
