using Movies_Catalogue.Models;

namespace Movies_Catalogue.Interfaces
{
    public interface IValidateMovie
    {
        void Validate(MovieRequest NewMovie);
        void CheckDataIds(MovieRequest New);
    }
}
