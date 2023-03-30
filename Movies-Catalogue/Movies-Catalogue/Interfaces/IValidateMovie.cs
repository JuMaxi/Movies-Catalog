using Movies_Catalogue.Models;

namespace Movies_Catalogue.Interfaces
{
    public interface IValidateMovie
    {
        void Validate(Movie NewMovie);
        void CheckDataIds(Movie New);
    }
}
