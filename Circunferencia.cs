using System;
using TDSN2024;
namespace FormaCircunferencia
{

    class Circunferencia : FormaGeometrica
    {
        private double raio;

        public double Raio
        {
            get { return raio; }
            set { raio = value; }
        }
        public override double CalcularPerimetro() => 2 * Math.PI * Raio;

        public override double CalcularArea() => Math.PI * Math.Pow(Raio, 2);

        public override string ToString()
        {
            return $"Circunferência({raio})";
        }
    }

}
}