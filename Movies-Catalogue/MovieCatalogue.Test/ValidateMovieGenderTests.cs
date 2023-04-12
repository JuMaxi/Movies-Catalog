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
    public class ValidateMovieGenderTests
    {
        [Fact]
        public void GivenThatIHaveAMovieGender_WhenMovieGenderisNull_ThenShowException()
        {
            MovieGenderRequest MovieGender = new MovieGenderRequest();

            MovieGender.Gender = null;

            ValidateMovieGender ValidateMovieGender = new ValidateMovieGender();

            ValidateMovieGender.Invoking(Validate => Validate.ValidateGender(MovieGender))
                .Should().Throw<Exception>().WithMessage("The field Gender can't be empty or null. Please fill the gender to continue.");
        }

        [Fact]
        public void GivenThatIHaveAMovieGender_WhenMovieLengthGenderisZero_ThenShowException()
        {
            MovieGenderRequest MovieGender = new MovieGenderRequest();

            MovieGender.Gender = "";

            ValidateMovieGender ValidateMovieGender = new ValidateMovieGender();


            ValidateMovieGender.Invoking(Validate => Validate.ValidateGender(MovieGender))
                .Should().Throw<Exception>().WithMessage("The field Gender can't be empty or null. Please fill the gender to continue.");
        }
    }
}
