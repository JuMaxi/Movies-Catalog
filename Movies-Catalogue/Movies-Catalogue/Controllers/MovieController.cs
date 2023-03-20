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
    public class MovieController : ControllerBase
    {
        AddMovie AddMovie = new AddMovie();
        BoxOffice BoxOffice= new BoxOffice();
        ActorRole ActorR = new ActorRole();

        [HttpPost]

        public void AddMo(Movie Movie)
        {
            AddMovie.NewMovie(Movie);
            BoxOffice.AddBoxOffice(Movie.BoxOffice);

            for(int Position = 0; Position < Movie.ActorRole.Count; Position++)
            {
                ActorR.AddCast(Movie.ActorRole[Position]);
            }
        }
    }
}
