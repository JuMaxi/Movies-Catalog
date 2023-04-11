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
    public class ValidateProducerTests
    {
        [Fact]
        public void GivenThatIHaveAProducer_WhenProducerNameisNull_ThenShowException()
        {
            ProducerRequest TestProducer = new ProducerRequest();
            TestProducer.Name = null;

            ValidateProducer ValidateProducer = new ValidateProducer();

            ValidateProducer.Invoking(Validate => Validate.Validate(TestProducer))
                .Should().Throw<Exception>().WithMessage("The Producer's Name is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAProducer_WhenProducerLengthNameIsZero_ThenShowException()
        {
            ProducerRequest TestProducer = new ProducerRequest();
            TestProducer.Name = "";

            ValidateProducer ValidateProducer = new ValidateProducer();

            ValidateProducer.Invoking(Validate => Validate.Validate(TestProducer)).
                Should().Throw<Exception>().WithMessage("The Producer's Name is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAProducer_WhenProducerEstablishedDateisFuture_ThenShowException()
        {
            ProducerRequest TestProducer = new ProducerRequest();

            TestProducer.Name = "Producer Test";
            TestProducer.EstablishedDate = DateTime.Now.AddDays(1);

            ValidateProducer ValidateProducer = new ValidateProducer();
            ValidateProducer.Invoking(Validate => Validate.Validate(TestProducer))
                .Should().Throw<Exception>().WithMessage("The Established Date must be smaller than the actual date.");
        }

        [Fact]
        public void GivenThatIHaveAProducer_WhenProducerPlaceisNull_ThenShowException()
        {
            ProducerRequest TestProducer = new ProducerRequest();

            TestProducer.Name = "Producer Test";
            TestProducer.EstablishedDate = DateTime.Now.AddDays(-1);
            TestProducer.Place = null;

            ValidateProducer ValidateProducer = new ValidateProducer();

            ValidateProducer.Invoking(Validate => Validate.Validate(TestProducer))
                .Should().Throw<Exception>().WithMessage("The Producer's Place is mandatory. Fill out this field to continue.");
        }

        [Fact]
        public void GivenThatIHaveAProducer_WhenProducerLengthPlaceisZero_ThenShowException()
        {
            ProducerRequest TestProducer = new ProducerRequest();

            TestProducer.Name = "Producer Test";
            TestProducer.EstablishedDate= DateTime.Now.AddDays(-1);
            TestProducer.Place = "";

            ValidateProducer ValidateProducer = new ValidateProducer();

            ValidateProducer.Invoking(Validate => Validate.Validate(TestProducer))
                .Should().Throw<Exception>().WithMessage("The Producer's Place is mandatory. Fill out this field to continue.");
        }
    }
}
