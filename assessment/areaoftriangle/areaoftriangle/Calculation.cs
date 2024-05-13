using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace areaoftriangle
{
    public class Calculation
    {
       // method
        public int AreaOfTriangle(int bottom, int height)
        {
            int response = (bottom * height) / 2;
            return response;
        }

        public int Rectangle(int lenght, int width)
        {
            int response = (lenght * width);
            return response;

        }
        public double Circumference(double pi, double radius)
        {
            double response = (pi * (radius * radius));
            return response;
        }
    }
}
