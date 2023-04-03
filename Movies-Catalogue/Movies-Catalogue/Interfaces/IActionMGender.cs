using Movies_Catalogue.Models;
using System.Collections.Generic;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionMGender
    {
        void NewGender(MovieGenderRequest NewGender);
        List<MovieGenderRequest> ShowGender();
        void UpdateGender(MovieGenderRequest MovieGender);
        void DeleteGender(int Id);
    }
}
