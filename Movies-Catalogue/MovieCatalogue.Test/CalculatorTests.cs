using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieCatalogue.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void GivenTwoNumbers_WhenSummingThem_ShouldBeTheCorrectSum()
        {
            // AAA = Arrange, Act, Assert (Arrumar - preparo inicial, Agir - chamar o seu codigo, Validar)
            // Arrange 
            int numero1 = 2;
            int numero2 = 3;

            // Act
            int resultado = new Calculator().Somar(numero1, numero2);

            // Assert
            resultado.Should().Be(5);
        }

        [Fact]
        public void GivenTwoNumbers_WhenSubtractedThem_ShoulBeTheCorrectSubtract() 
        { 
            int numero1 = 5;
            int numero2 = 3;

            int resultado = new Calculator().Subtrair(numero1, numero2);

            resultado.Should().Be(2);
        }

        [Fact]
        public void GivenTwoNumbers_WhenMultuplyingThem_ShoulBeTheCorrectMultiply()
        {
            int numero1 = 2;
            int numero2 = 5;

            int resultado = new Calculator().Mulitiplicar(numero1, numero2);

            resultado.Should().Be(10);
        }
        [Fact]
        public void GivenTwoNumbers_WhenDividingthem_ShouldBeTheCorrectDivision() 
        {
            int numero1 = 10;
            int numero2 = 2;

            
            int resultado = new Calculator().Divisao(numero1, numero2);
            resultado.Should().Be(5);

        }

        [Fact]
        public void WhenDividingByZero_ShouldThrowException()
        {
            int numero1 = 10;
            int numero2 = 0;

            var calculadora = new Calculator();
            calculadora.Invoking(calculator => calculator.Divisao(numero1, numero2))
                .Should().Throw<Exception>().WithMessage("It's impossible to divid one number for zero. Change the number to continue.");

        }


        [Fact]
        public void GivenTwoNumbers_WhenPotencia_ShouldBeTheCorrectPotencia()
        {
            int numero1 = 3;
            int numero2 = 3;

            int resultado = new Calculator().Potencia(numero1, numero2);
            resultado.Should().Be(27);
        }
        
    }
}
