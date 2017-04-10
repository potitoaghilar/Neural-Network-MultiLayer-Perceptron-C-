using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace Agent
{
    class GAProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Genetic Algorithm + Neural Network ~ Testing";

            // Testing Genetic Algorithm combined with Neural Network
            GeneticController GController = new GeneticController(10, 10, 2, new int[] { 50, 50 }, 1);
            GController.createGeneration();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress a key to exit...");
            Console.ReadLine();
        }
    }
}
