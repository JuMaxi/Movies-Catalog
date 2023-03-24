using Movies_Catalogue.Models;
using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using System.Data.SqlClient;

namespace Movies_Catalogue.Services
{
    public class ActionProducer
    {
        AccessDB AccessDB = new AccessDB();
        ValidateProducer ValidateProducer = new ValidateProducer();
        public void AddNewProducer(Producer NewProducer)
        {
            ValidateProducer.Validate(NewProducer);

            string Insert = "insert into Producer (Name, EstablishedDate, Place, NumberEmployees, Website) values ('" + NewProducer.Name + "','" + NewProducer.EstablishedDate.ToString("yyyy-MM-dd") + "','" + NewProducer.Place + "'," + NewProducer.NumberEmployees + ",'" + NewProducer.Website + "')";

            AccessDB.AccessNonQuery(Insert);
        }

        public List<Producer> ShowProducers()
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

        public void UpdateProducer(Producer Producer)
        {
            string Update = "Update Producer set Name='" + Producer.Name + "', EstablishedDate='" + Producer.EstablishedDate.ToString("yyyy-MM-dd") + "', Place='" + Producer.Place + "', NumberEmployees=" + Producer.NumberEmployees + ", Website='" + Producer.Website + "' where Id=" + Producer.Id;

            AccessDB.AccessNonQuery(Update);
        }
    }
}
