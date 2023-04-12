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
    public class ValidateActorTests
    {
        [Fact]
        public void GivenThatIHaveAnActor_WhenActorNameisNull_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = null;

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The actor's name + last name is mandatory. Fill this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorLengthNameIsNull_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "";

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The actor's name + last name is mandatory. Fill this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorNameDoesntHaveLastName_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "JoaoNoLastName";

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The actor's name + last name is mandatory. Fill this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorSexisNull_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "Joao da Silva";
            Actor.Sex = null;

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The biological sex is mandatory. Choose, male or female to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorLengthSexIsZero_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "Joao da Silva";
            Actor.Sex = "";

            ValidateActor ValidateActor = new ValidateActor();
                
            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The biological sex is mandatory. Choose, male or female to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorPlaceOfBirthisNull_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "Joao da Silva";
            Actor.Sex = "Male";
            Actor.PlaceOfBirth = null;

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The place of Birth is mandatory. Fill this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorLengthPlaceOfBirthIsZero_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "Joao da Silva";
            Actor.Sex = "Male";
            Actor.PlaceOfBirth = "";

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor))
                .Should().Throw<Exception>().WithMessage("The place of Birth is mandatory. Fill this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorDateOfBirthIsFuture_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "Joao da Silva";
            Actor.Sex = "Male";
            Actor.PlaceOfBirth = "Brazil";
            Actor.DateOfBirth = DateTime.Now.AddDays(1);

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor)).Should().Throw<Exception>()
                .WithMessage("The DateOfBirth is mandatory and can't be bigger than the date actual or the Date of the movie.");
        }

        [Fact]
        public void GivenThatIHaveAnActor_WhenActorDateOfBirthIsFutureThanMovieDateRelease_ThenShowException()
        {
            Actor Actor = new Actor();
            Actor.Name = "Joao da Silva";
            Actor.Sex = "Male";
            Actor.PlaceOfBirth = "Brazil";
            Actor.DateOfBirth = DateTime.Now;

            ValidateActor ValidateActor = new ValidateActor();

            ValidateActor.Invoking(Validate => Validate.Validate(Actor)).Should().Throw<Exception>()
                .WithMessage("The DateOfBirth is mandatory and can't be bigger than the date actual or the Date of the movie.");
        }
    }
}
