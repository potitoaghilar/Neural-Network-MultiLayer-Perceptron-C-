using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;
using System.Drawing;

namespace Agent
{
    class NNProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Neural Network Testing";

            // Testing Neural Network giving it 3 input values for 100 times (testing with 520 neurons)
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                NeuroNetwork net = new NeuroNetwork(3, new int[] { 100, 200, 200, 20 }, 1, random);
                double[] result = net.elaborate(new double[] { 0, .5, 0 });
                foreach (double r in result)
                {
                    if (r < .3) Console.ForegroundColor = ConsoleColor.Red;
                    else if (r > .7) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(r);
                }
                System.Threading.Thread.Sleep(10);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress a key to exit...");
            Console.ReadLine();
        }
    }
}
