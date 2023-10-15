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
        //стороны
        public double a;
        public double b;
        public double c;
        private string type;
        //private string kraad;

        public Triangle(double A, double B, double C)//конструктор
        {
            a = A;
            b = B;
            c = C;
            type = "Määratlemata";
            if (a == b && c == a)
            {
                type = "Võrdkülgne";
            }
            else if (a == b && c == a && b != c)
            {
                type = "Võrdhaarne";
            }
            else if (a != b && c != a && b != c)
            {
                type = "Mitmekülgne";
            }
        }

        public string TrianType
        {
            get { return type; }
        }

        //public string TrianKrad
        //{
        //    get { return kraad; }
        //}

        public string OutputA()//возращение в строковом значении
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

        public double Perimeter()//сумма всех сторон/периметр треугольника
        {
            return a + b + c;
        }

        public double Surface()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
        public double GetSetA //установка либо смена значения стороны а
        {
            get
            { return a; }
            set
            { a = value; }

        }

        public double GetSetB
        {
            get
            { return b; }
            set
            { b = value; }

        }

        public double GetSetC
        {
            get
            { return c; }
            set
            { c = value; }

        }

        public bool ExistTriange//опредедение существуеи ли треугольник с прописанными сторонами
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))//сумма 2 сторон обязательно должна быть больше чем 3-я
                    return true;
                else return false;
            }
        }


    }
}
