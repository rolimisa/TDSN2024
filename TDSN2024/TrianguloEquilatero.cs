using System;

namespace TDSN2024
{
    class TrianguloEquilatero : Triângulo
    {
        public override double CalcularArea()
        {
            altura = _base * (Math.Sqrt(3)) / 2;
            return (_base * altura) / 2;
        }

        public override double CalcularPerimetro()
        {
            return _base * 3;
        }
        public override double CalcularHipotenusa()
        {
            return Math.Sqrt(Math.Pow(_base, 2) + Math.Pow(altura, 2));
        }
        public override string ToString()
        {
            return $"T.Equilátero({_base}, {altura})";
        }
    }
}
