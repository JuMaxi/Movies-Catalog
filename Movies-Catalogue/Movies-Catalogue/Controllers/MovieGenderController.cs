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
        public void AddMovieGender(MovieGenderRequest NewGender)
        {
            ActionMGender.NewGender(NewGender);
        }

        [HttpGet]
        public List<MovieGenderRequest> ShowMovieGenders()
        {
            List<MovieGenderRequest> ListGender = new List<MovieGenderRequest>();
            ListGender = ActionMGender.ShowGender();
            return ListGender;
        }

        [HttpPut]
        public void UpdateGender(MovieGenderRequest MovieGender)
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
