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
    public class ProducerController : ControllerBase
    {
        AddProducer AddProd = new AddProducer();
        AccessDB AccessDB = new AccessDB();

        [HttpPost]
        public void AddProducer (Producer NewProducer)
        {
            AddProd.AddNewProducer (NewProducer);
        }

        [HttpGet]
        public List<Producer> ShowProducer()
        {
            List<Producer> ListProducer = new List<Producer>();

            string Select = "select * from Producer";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                Producer Producer = new Producer();

                Producer.Id = Convert.ToInt32(Reader["Id"]);
                Producer.Name = Convert.ToString(Reader["Name"]);
                Producer.EstablishedDate = Convert.ToDateTime(Reader["EstablishedDate"]);
                Producer.Place = Convert.ToString(Reader["Place"]);
                Producer.NumberEmployees = Convert.ToInt32(Reader["NumberEmployees"]);
                Producer.Website = Convert.ToString(Reader["Website"]);

                ListProducer.Add(Producer);
            }
            return ListProducer;
        }
    }
}
