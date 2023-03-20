using Movies_Catalogue.Services;
using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class ActorRole
    {
        public int ActorId { get; set; }
        public string Role { get; set; }

        AccessDB AccessDB = new AccessDB();
        public void AddCast(ActorRole ActorRole)
        {
            string Insert = "insert into Castt (ActorId, Role) values(" + ActorRole.ActorId + "," + ActorRole.Role + ")";

            AccessDB.AccessNonQuery(Insert);
        }
    }
}
