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

            // Testing Genetic Algorithm combined with Neural Network of 200 neurons
            GeneticController GController = new GeneticController(12, 3, new int[] { 80, 120 }, 1);

            // Learning process for 100 generations
            for (int i = 0; i < 100; i++)
            {
                GController.createGeneration();
                printResultsAndSetFitness(GController);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress a key to exit...");
            Console.ReadLine();
        }

        static void printResultsAndSetFitness(GeneticController g_ctrl)
        {
            Console.Clear();
            double[][] result = g_ctrl.executeGeneration(new double[] { .1, .5, .7 });
            double[] fitness = new double[result.Length];
            int index = 0;
            foreach (double[] r in result)
            {
                if (r[0] <= .4) Console.ForegroundColor = ConsoleColor.Red;
                else if (r[0] >= .6) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(r[0]);

                if (r[0] > .4 && r[0] < .6)
                    fitness[index] = 1 - (10 * Math.Abs(.5 - r[0])); // Funzione di fitness
                else fitness[index] = 0;

                index++;
            }
            g_ctrl.setFitness(fitness);
            Console.WriteLine();
        }
    }
}
