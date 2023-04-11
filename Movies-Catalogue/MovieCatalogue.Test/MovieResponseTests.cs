using FluentAssertions;
using Movies_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieCatalogue.Test
{
    public class MovieResponseTests
    {
        [Fact]

        public void GivenThatIHaveAMovieResponse_WhenIAddALocation_ThenItShouldAppearLocationToListLocations()
        {
            string Location = "Brazil";

            MovieResponse MovieLocation = new MovieResponse();

            MovieLocation.AddFilmingLocation(Location);

            MovieLocation.Locations.Should().HaveCount(1);

        }

        [Fact]
        public void GivenThatIHaveAMovieResponse_WhenIAddALocationTwice_ThenItShouldNotAppearTwiceToListLocations()
        {
            string Location = "Brazil";

            MovieResponse MovieLocation = new MovieResponse();

            MovieLocation.AddFilmingLocation(Location);
            MovieLocation.AddFilmingLocation(Location);

            MovieLocation.Locations.Should().HaveCount(1);

        }
        [Fact]
        public void GivenThatIHaveAMovieResponse_WhenIAddANewLocation_ThenItShouldAppearAlsoToListLocations()
        {
            string Location1 = "Brazil";
            string Location2 = "Chile";

            MovieResponse MovieLocation = new MovieResponse();

            MovieLocation.AddFilmingLocation(Location1);
            MovieLocation.AddFilmingLocation(Location2);

            MovieLocation.Locations.Should().HaveCount(2);
        }

        [Fact]
        public void GivenThatIHaveAMovieCastResponse_WhenIAddAMovieCast_ThenItShouldAppearMovieCastToListMovieCast()
        {
            int ActorId = 5;
            string Role = "Puss of Boots";
            string ActorName = "Joao da Silva";

            MovieResponse MovieCast = new MovieResponse();
            
            MovieCast.AddMovieCast(ActorId, Role, ActorName);

            MovieCast.MovieCast.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAMovieCastResponse_WhenIAddAMovieCastTwice_ThenItShouldNotAppearMovieCastToListMovieCastTwice()
        {
            int ActorId = 5;
            string Role = "Puss of Boots";
            string ActorName = "Joao da Silva";

            MovieResponse MovieCast = new MovieResponse();

            MovieCast.AddMovieCast(ActorId, Role, ActorName);
            MovieCast.AddMovieCast(ActorId, Role, ActorName);

            MovieCast.MovieCast.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAMovieCastResponse_WhenIAddANewMovieCast_ThenItShouldAppearNewMovieCastToListMovieCast()
        {
            int ActorId = 5;
            string Role = "Puss of Boots";
            string ActorName = "Joao da Silva";

            int ActorId2 = 6;
            string Role2 = "Fiona";
            string ActorName2 = "Joana da Silva";

            MovieResponse MovieCast = new MovieResponse();

            MovieCast.AddMovieCast(ActorId, Role, ActorName);
            MovieCast.AddMovieCast(ActorId2, Role2, ActorName2);

            MovieCast.MovieCast.Should().HaveCount(2);
        }
    }
}
