using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;
using Movies_Catalogue.Interfacies;
using Microsoft.Extensions.Configuration;

namespace Movies_Catalogue.Services
{
    public class AccessDB : IAccessDB
    {
        string ConnectionString = "";

        public AccessDB(IConfiguration Configuration)
        {
            ConnectionString = Configuration.GetSection("ConnectionString").Value;
        }

        public void AccessNonQuery(string Action)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            {
                SqlCommand Command = new SqlCommand(Action, Connection);
                Connection.Open();

                Command.ExecuteNonQuery();
            }
        }
        public IDataReader AccessReader(string Action)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(Action, Connection);
            Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            return Reader;
        }
    }
}
