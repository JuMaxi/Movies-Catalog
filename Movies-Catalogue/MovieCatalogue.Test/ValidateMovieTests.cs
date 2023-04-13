using FluentAssertions;
using Movies_Catalogue.Models;
using Movies_Catalogue.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieCatalogue.Test
{
    public class ValidateMovieTests
    {
        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieTitleisNull_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = null;

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Title is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieLengthTitleIsZero_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "";

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Title is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieCoverImageisNull_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = null;

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Cover Image is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieLengthCoverImageIsZero_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = "";

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Cover Image is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieReleaseDateisBeforeFirstMovie_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = "CoverImage Tests";
            Movie.ReleaseDate = new DateTime(1894, 01, 01);

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Release Date is invalid. Fill again this field with a valid date to continue.");
        }
        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieReleaseDateisFuture_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = "Cover Image Tests";
            Movie.ReleaseDate = DateTime.Now.AddDays(1);

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Release Date is invalid. Fill again this field with a valid date to continue.");
        }
        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieLengthIsZero_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = "Cover Image Tests";
            Movie.ReleaseDate = DateTime.Now.AddDays(-1);   
            Movie.Length = 0;

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie)).Should().Throw<Exception>()
                .WithMessage("The Movie's Length is mandatory and must be bigger than zero. Fill out this field with a valid value to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieOriginisNull_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = "Cover Image Tests";
            Movie.ReleaseDate = DateTime.Now.AddDays(-1);
            Movie.Length = 100;
            Movie.Origin = null;

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Movie's Origin is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovie_WhenMovieLengthOriginIsZero_ThenShowException()
        {
            MovieRequest Movie = new MovieRequest();
            Movie.Title = "Puss of Boots";
            Movie.CoverImage = "Cover Image Tests";
            Movie.ReleaseDate = DateTime.Now.AddDays(-1);
            Movie.Length = 100;
            Movie.Origin = "";

            ValidateMovie ValidateMovie = new ValidateMovie(null);

            ValidateMovie.Invoking(Validate => Validate.Validate(Movie))
                .Should().Throw<Exception>().WithMessage("The Movie's Origin is mandatory. Fill out this field to continue.");
        }
    }
}
