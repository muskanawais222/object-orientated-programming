using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4.BL
{
    class Rectangle : Shape
    {
        private double width;
        private double height;
        // parameterized constructor
        public Rectangle(double width , double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double area()
        {
            double area = height * width;
            return area;
        }
        public override string tostring()
        {
            return "The shape is Rectangle and its Area is " + area();
        }
    }
}
