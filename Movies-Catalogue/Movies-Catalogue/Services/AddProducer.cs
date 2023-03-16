using Movies_Catalogue.Models;
using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;

namespace Movies_Catalogue.Services
{
    public class AddProducer
    {
        AccessDB AccessDB = new AccessDB();
        ValidateProducer ValidateProducer = new ValidateProducer();
        public void AddNewProducer(Producer NewProducer)
        {
            ValidateProducer.Validate(NewProducer);

            string Insert = "insert into Producer (Name, EstablishedDate, Place, NumberEmployees, Website) values ('" + NewProducer.Name + "','" + NewProducer.EstablishedDate.ToString("yyyy-MM-dd") + "','" + NewProducer.Place + "'," + NewProducer.NumberEmployees + ",'" + NewProducer.Website + "')";

            AccessDB.AccessNonQuery(Insert);
        }
    }
}
