using Movies_Catalogue.Models;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionMovie
    {
        void NewMovie(MovieRequest New);
        MovieResponse ShowMovie(int Id);
    }
}
