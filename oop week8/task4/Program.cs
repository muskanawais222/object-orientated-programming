using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task4.UI;
using task4.BL;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Rectangle rectangle = Rectangle_UI.rectangleInfo();
            shapes.Add(rectangle);
            Circle circle = CircleUI.circleInfo();
            shapes.Add(circle);
            Square square = Square_UI.squareInfo();
            shapes.Add(square);
           
            Rectangle rectangle1 = Rectangle_UI.rectangleInfo();
            shapes.Add(rectangle1);
            Circle circle1 = CircleUI.circleInfo();
            shapes.Add(circle1);


            foreach (Shape s in shapes)
            {
                Console.WriteLine(s.tostring()); 
            }
            Console.ReadKey();

        }
    }
}
