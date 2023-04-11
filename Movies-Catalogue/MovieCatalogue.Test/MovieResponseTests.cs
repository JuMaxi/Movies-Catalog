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
        public void GivenThatIHaveAMovieResponse_WhenIAddANewLocation_ThenItShouldAppearToListLocations()
        {
            string Location1 = "Brazil";
            string Location2 = "Chile";

            MovieResponse MovieLocation = new MovieResponse();

            MovieLocation.AddFilmingLocation(Location1);
            MovieLocation.AddFilmingLocation(Location2);

            MovieLocation.Locations.Should().HaveCount(2);
        }

        [Fact]
        public void GivenThatIHaveAMovieCastResponse_WhenIAddAMovieCast_ThenItShouldAppearToListMovieCast()
        {
            int ActorId = 5;
            string Role = "Puss of Boots";
            string ActorName = "Joao da Silva";

            MovieResponse MovieCast = new MovieResponse();
            
            MovieCast.AddMovieCast(ActorId, Role, ActorName);

            MovieCast.MovieCast.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAMovieCastResponse_WhenIAddAMovieCastTwice_ThenItShouldNotAppearTwiceToListMovieCast()
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
        public void GivenThatIHaveAMovieCastResponse_WhenIAddANewMovieCast_ThenItShouldAppearNewToListMovieCast()
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

        [Fact]
        public void GivenThatIHaveAMovieGenderResponse_WhenIAddAMovieGender_ThenItShouldAppearToListMovieGenders() 
        {
            int GenderId = 3;
            string Gender = "Romance";

            MovieResponse MovieGender = new MovieResponse();

            MovieGender.AddMovieGender(GenderId, Gender);

            MovieGender.MovieGender.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAMovieGenderResponse_WhenIAddAMovieGenderTwice_ThenItShouldNotAppearTwiceToListMovieGenders()
        {
            int GenderId = 3;
            string Gender = "Romance";

            MovieResponse MovieGender = new MovieResponse();

            MovieGender.AddMovieGender(GenderId, Gender);
            MovieGender.AddMovieGender(GenderId, Gender);

            MovieGender.MovieGender.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAMovieGenderResponse_WhenIAddANewMovieGender_ThenItShouldAppearANewToListMovieGenders()
        {
            int GenderId = 3;
            string Gender = "Romance";

            int GenderId2 = 4;
            string Gender2 = "Drama";

            MovieResponse MovieGender = new MovieResponse();
            MovieGender.AddMovieGender(GenderId, Gender);
            MovieGender.AddMovieGender(GenderId2, Gender2);

            MovieGender.MovieGender.Should().HaveCount(2);
        }

        [Fact]
        public void GivenThatIHaveAProducerResponse_WhenIAddAProducer_ThenItShouldAppearToListProducers()
        {
            int ProducerId = 7;
            string Producer = "Dream Works";

            MovieResponse MovieProducer = new MovieResponse();
            
            MovieProducer.AddProducer(ProducerId, Producer);

            MovieProducer.Producers.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAProducerResponse_WhenIAddAProducerTwice_ThenItShouldNotAppearToListProducersTwice()
        {
            int ProducerId = 7;
            string Producer = "DreamWorks";

            MovieResponse MovieProducer = new MovieResponse();

            MovieProducer.AddProducer(ProducerId, Producer);
            MovieProducer.AddProducer(ProducerId, Producer);

            MovieProducer.Producers.Should().HaveCount(1);
        }

        [Fact]
        public void GivenThatIHaveAProducerResponse_WhenIAddANewProducer_ThenItShoudAppearNewToListProducers()
        {
            int ProducerId = 7;
            string Producer = "Dream Works";

            int ProducerId2 = 8;
            string Producer2 = "Disney";

            MovieResponse MovieProducer = new MovieResponse();

            MovieProducer.AddProducer(ProducerId, Producer);
            MovieProducer.AddProducer(ProducerId2, Producer2);

            MovieProducer.Producers.Should().HaveCount(2);
        }
    }
}
