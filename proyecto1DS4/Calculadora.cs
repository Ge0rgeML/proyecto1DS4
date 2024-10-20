using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1DS4
{
    internal class Calculadora
    {
        public double Sumar(double a, double b) => a + b;

        public double Restar(double a, double b) => a - b;

        public double Multiplicar(double a, double b) => a * b;

        public double Dividir(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");
            return a / b;
        }

        public double Cuadrado(double a) => a * a;

        public double Raiz(double a)
        {
            if (a < 0)
                throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo.");
            return Math.Sqrt(a);
        }
    }
}
