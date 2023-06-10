using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.BL
{
    class Circle
    {
        protected double radius = 1.0;
        protected string color = "Red";
        // constructor
        public Circle () // default constructor
        {

        }
         //Single parameterized constructor

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius , string color)
        {
            this.radius = radius;
            this.color = color;
        }
        // functions 
        public double getRadius()
        {
            return radius;
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        /////// color////
        public string getColor()
        {
            return color;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public double getArea()
        {
            double area;
            area =  3.14 * radius * radius;
            return area;
        }
        public string toString()
        {
            return "Radius: " + radius+"\n" + "Color: "+ color + "\n" + "Area of Circle: " + getArea();
            
        }
    }
}
