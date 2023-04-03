using Microsoft.AspNetCore.Mvc;
using Movies_Catalogue.Models;
using Movies_Catalogue.Services;
using Movies_Catalogue.Validators;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Movies_Catalogue.Interfaces;


namespace Movies_Catalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        IActionMovie ActionMovie;
        public MovieController(IActionMovie Movie) 
        {
            ActionMovie = Movie;
            
        }

        [HttpPost]
        public void AddMovie(MovieRequest Movie)
        {
            ActionMovie.NewMovie(Movie);
        }

        [HttpGet("{Id}")]
        public MovieResponse ShowMovie([FromRoute] int Id)
        {
            MovieResponse Movie = new MovieResponse();

            Movie = ActionMovie.ShowMovie(Id);

            return Movie;
        }
    }
}
