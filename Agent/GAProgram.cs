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
            GeneticController GController = new GeneticController(2, 12, 3, new int[] { 50, 50, 20 }, 1);
            GController.createGeneration();

            // Learning process
            printResultsAndSetFitness(GController);
            GController.createGeneration();
            printResultsAndSetFitness(GController);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress a key to exit...");
            Console.ReadLine();
        }

        static void printResultsAndSetFitness(GeneticController g_ctrl)
        {
            double[][] result = g_ctrl.executeGeneration(new double[] { 0, 1, 0 });
            double[] fitness = new double[result.Length];
            int index = 0;
            foreach (double[] r in result)
            {
                if (r[0] <= .4) Console.ForegroundColor = ConsoleColor.Red;
                else if (r[0] >= .6) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(r[0]);

                if (r[0] > .4 && r[0] < .6)
                    fitness[index] = 10 * Math.Abs(.5 - r[0]); // Funzione di fitness
                else fitness[index] = 0;

                index++;
            }
            g_ctrl.setFitness(fitness);
            Console.WriteLine();
        }
    }
}
