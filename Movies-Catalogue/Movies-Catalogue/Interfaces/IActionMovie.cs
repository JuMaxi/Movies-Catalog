using Movies_Catalogue.Models;
using System.Collections.Generic;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionMovie
    {
        void NewMovie(MovieRequest New);
        MovieResponse ShowMovie(int Id);

        public List<MovieResponse> ShowListMovies(int Page, int Size);
    }
}
