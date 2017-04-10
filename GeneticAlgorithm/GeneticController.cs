using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace GeneticAlgorithm
{
    public class GeneticController
    {

        // GA params
        private int generations_count, genomes_count, current_generation = 0;
        private Random random = new Random();
        NeuroNetwork[] genomes;

        // NeuroNetwork params
        private int neuro_input_nodes, neuro_output_nodes;
        private int[] neurons_per_layer;
        

        public GeneticController(int generations_count, int genomes_count, int neuro_input_nodes, int[] neurons_per_layer, int neuro_output_nodes)
        {
            // Set GA params
            this.generations_count = generations_count;
            this.genomes_count = genomes_count;
            this.neuro_input_nodes = neuro_input_nodes;
            this.neurons_per_layer = neurons_per_layer;
            this.neuro_output_nodes = neuro_output_nodes;
        }

        public void createGeneration()
        {
            if (current_generation++ == 0)
            {
                // Generate random genomes on first generation
                genomes = new NeuroNetwork[genomes_count];

                for (int i = 0; i < genomes.Length; i++)
                {
                    genomes[i] = new NeuroNetwork(neuro_input_nodes, neurons_per_layer, neuro_output_nodes, random);
                }
            }
        }

    }
}
