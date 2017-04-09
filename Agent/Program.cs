using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Agent
{
    class Program
    {
        static void Main(string[] args)
        {
            Network net = new Network(2, new int[] { 3, 3 }, 2);

            double[] result = net.elaborate(new double[] { 5, 0, 10 });
            foreach (double r in result)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
    }
}
