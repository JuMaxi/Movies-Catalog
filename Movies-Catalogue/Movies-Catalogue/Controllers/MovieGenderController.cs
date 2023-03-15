using Microsoft.AspNetCore.Mvc;
using Movies_Catalogue.Models;
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
        AddMGender AddGender = new AddMGender();
        
        [HttpPost]
        public void AddMovieGender(MovieGender NewGender)
        {
            AddGender.AddNewGender(NewGender);
        }
        
        [HttpGet]
        public List<MovieGender> ShowMovieGenders()
        {
            List<MovieGender> ListGender = new List<MovieGender>();

            string Select = "select * from Genders";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                MovieGender MovieGender = new MovieGender();

                MovieGender.Id = Convert.ToInt32(Reader["Id"]);
                MovieGender.Gender = Convert.ToString(Reader["Gender"]);
                
                ListGender.Add(MovieGender);
            }
            return ListGender;
        }
    }
}
