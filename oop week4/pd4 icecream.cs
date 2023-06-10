using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using icecream;

namespace icecream
{
    class Program
    {
        public class IceCream
        {
            public string Name { get; set; }
            public int Flavour { get;set; }

            public IceCream(string flavour, int no)
            {
                Name = flavour;
                Flavour = no;
            }


            static void Main(string[] args)
            {
                List<IceCream> ices = new List<IceCream>();

                Console.WriteLine(sweetestIcecream(ices));
            }
            public static List<IceCream> GetIceCreamsFromInput()
            {
                List<IceCream> iceCreams = new List<IceCream>();

                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; ++i)
                {
                    string[] _params = Console.ReadLine().Split(' ');
                    IceCream _iceCream = new IceCream(_params[0], int.Parse(_params[1]));
                    iceCreams.Add(_iceCream);
                }

                return iceCreams;
            }
            public static int SweetestIceCream(List<IceCream> icecream )
            {
                int sweetness = 0;
                foreach (icecream ice in icecream)
                {

                    sweetness = Math.Min(sweetness, ice.Flavour);

                }
                return sweetness;
            }

        }
    }
}
