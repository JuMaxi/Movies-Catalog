using Movies_Catalogue.Models;

namespace Movies_Catalogue.Interfaces
{
    public interface IValidateMovieGender
    {
        void ValidateGender(MovieGenderRequest gender);
    }
}
