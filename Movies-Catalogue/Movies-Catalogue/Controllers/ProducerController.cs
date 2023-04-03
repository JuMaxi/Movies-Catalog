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
    public class ProducerController : ControllerBase
    {
        IActionProducer ActionProducer;

        public ProducerController(IActionProducer ActionPro) 
        {
            ActionProducer = ActionPro;
        }

        [HttpPost]
        public void AddProducer(ProducerRequest NewProducer)
        {
            ActionProducer.NewProducer(NewProducer);
        }

        [HttpGet]
        public List<ProducerRequest> ShowProducer()
        {
            List<ProducerRequest> ListProducer = new List<ProducerRequest>();
            ListProducer = ActionProducer.ShowProducers();
            return ListProducer;
        }

        [HttpPut]
        public void UpdateProducer(ProducerRequest Producer)
        {
            ActionProducer.UpdateProducer(Producer);
        }

        [HttpDelete]
        public void DeleteProducer([FromQuery]int Id)
        {
            ActionProducer.DeleteProducer(Id);
        }
        
    }
}
