using Movies_Catalogue.Models;
using System.Collections.Generic;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionActor
    {
        void AddNewActor(Actor NewActor);
        void DeleteActor(int Id);
        List<Actor> ShowActors();
        void UpdateActor(Actor Actor);
    }
}
