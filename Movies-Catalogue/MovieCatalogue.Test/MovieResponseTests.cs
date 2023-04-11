using FluentAssertions;
using Movies_Catalogue.Models;
using System;
using System.Collections.Generic;
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
    }
}
