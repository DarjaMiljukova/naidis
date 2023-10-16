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



//private void Run_button_Click(object sender, EventArgs e)
//{
//    double a, b, c;
//    a = Convert.ToDouble(txtA.Text);
//    b = Convert.ToDouble(txtB.Text);
//    c = Convert.ToDouble(txtC.Text);
//    Triangle triangle = new Triangle(a, b, c);
//    listView1.Items.Add("Külg a");
//    listView1.Items.Add("Külg b");
//    listView1.Items.Add("Külg c");
//    listView1.Items.Add("Perimeter");
//    listView1.Items.Add("Ruut");
//    listView1.Items.Add("Kas on olemas?");
//    listView1.Items.Add("Täpsustaja");
//    listView1.Items[0].SubItems.Add(triangle.OutputA());
//    listView1.Items[1].SubItems.Add(triangle.OutputB());
//    listView1.Items[2].SubItems.Add(triangle.OutputC());
//    listView1.Items[3].SubItems.Add(Convert.ToString(triangle.Perimeter()));
//    listView1.Items[4].SubItems.Add(Convert.ToString(triangle.Surface()));
//    if (triangle.ExistTriangle) { listView1.Items[5].SubItems.Add("On olemas"); }
//    else listView1.Items[5].SubItems.Add("Ei ole");

//}


//private object txtA;
//private object txtB;
//private object txtC;