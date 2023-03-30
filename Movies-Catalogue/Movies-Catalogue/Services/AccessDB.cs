using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Movies_Catalogue.Services
{
    public interface IAccessDB
    {
        void AccessNonQuery(string Action);
        IDataReader AccessReader(string Action);
    }

    public class AccessDB : IAccessDB
    {
        string ConnectionString = "Server=LAPTOP-P4GEIO8K\\SQLEXPRESS;Database=MoviesCatalogue;User Id=sa;Password=S4root;";

        public void AccessNonQuery(string Action)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            {
                SqlCommand Command = new SqlCommand(Action, Connection);
                Connection.Open();

                Command.ExecuteNonQuery();
            }
        }
        //public SqlDataReader AccessReader(string Action)
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
