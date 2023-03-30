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
    public class MovieGenderController : ControllerBase
    {
        IActionMGender ActionMGender;

        public MovieGenderController(IActionMGender ActionMG)
        {
            ActionMGender = ActionMG;
        }

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

        [HttpDelete]
        public void DeleteGender([FromQuery] int Id)
        {
            ActionMGender.DeleteGender(Id);
        }

    }
}
