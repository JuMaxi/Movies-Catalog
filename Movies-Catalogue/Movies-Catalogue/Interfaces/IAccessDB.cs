using System.Data;

namespace Movies_Catalogue.Interfacies
{
    public interface IAccessDB
    {
        void AccessNonQuery(string Action);
        IDataReader AccessReader(string Action);
    }
}
