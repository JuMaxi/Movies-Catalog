using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogue.Test
{
    public class Calculator
    {
        public int Somar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public int Subtrair(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        public int Mulitiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        public int Divisao(int numero1, int numero2)
        {
            if (numero2 == 0)
            {
                throw new Exception("It's impossible to divid one number for zero. Change the number to continue.");
            }
            return numero1 / numero2;
        }

        public int Potencia(int numero1, int numero2)
        {
            int resultado = 1; 
            for(int Position = 0; Position < numero2; Position++)
            {
                resultado = resultado * numero2;
            }
            return resultado;
        }
    }
}
