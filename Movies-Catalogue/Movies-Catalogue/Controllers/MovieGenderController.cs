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
    public class MovieGenderController : ControllerBase
    {
        AccessDB AccessDB = new AccessDB();
        ActionMGender ActionMGender = new ActionMGender();
        
        [HttpPost]
        public void AddMovieGender(MovieGender NewGender)
        {
            ActionMGender.AddNewGender(NewGender);
        }
        
        [HttpGet]
        public List<MovieGender> ShowMovieGenders()
        {
            List<MovieGender> ListGender = new List<MovieGender>();
            ListGender = ActionMGender.ShowGender();
            return ListGender;
        }

        [HttpPut]
        public void UpdateGender(MovieGender MovieGender)
        {
            ActionMGender.UpdateGender(MovieGender);
        }

    }
}
