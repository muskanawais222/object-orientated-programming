using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.BL
{
    class Cylinder : Circle
    {
        private double height = 1.0;
        // default constructor
        public Cylinder()
        {

        }
        public Cylinder (double radius)
        {
            this.radius = radius;
           
        }
        public Cylinder(double radius , double height)
        {
            this.radius = radius;
            this.height = height;
        }
        public Cylinder(double radius, double height , string color)
        {
            this.radius = radius;
            this.height = height;
            this.color = color;
        }
        // function
        public double getHeight()
        {
            return height;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public double getVolume()
        {
            double volume;
            volume = 3.14 * radius * height;
            return height;
        }

        // to string 
        public string toString()
        {
            return "Radius: " + radius + " Color: " + color + " Height: " + height + " Area" + getArea() + " volume: " + getVolume();
        }
    }
}
