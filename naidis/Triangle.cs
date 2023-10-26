using naidis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace naidis
{

    public class Triangle
    {
        // Стороны
        public double a;
        public double b;
        public double c;
        private string type;
        private double median;

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;

            // Определяем тип треугольника
            if (a == b && b == c)
            {
                type = "Võrdkülgne";
            }
            else if (a == b || b == c || a == c)
            {
                type = "Võrdhaarne";
            }
            else
            {
                type = "Mitmekülgne";
            }
        }

        public string TrianType
        {
            get { return type; }
        }

        public string OutputA()
        {
            return Convert.ToString(a);
        }

        public string OutputB()
        {
            return Convert.ToString(b);
        }

        public string OutputC()
        {
            return Convert.ToString(c);
        }

        public double Perimeter()
        {
            return a + b + c;
        }

        public double Surface()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
        public double Height()
        {
            double s = Surface();
            double height = 2 * s / a;
            return height;
        }
        public double Median()
        {
            median = 0.5 * a;
            return median;
        }

        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }

        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }

        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }

        public bool ExistTriangle
        {
            get
            {
                if (a < b + c && b < a + c && c < a + b)
                    return true;
                else
                    return false;
            }
        }

    }
}