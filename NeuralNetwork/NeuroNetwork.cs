using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    // Considering the output layer as the result of last layer of HLs
    public class NeuroNetwork
    {
        
        // Network params
        private int input_nodes, output_nodes, hidden_layers_count;
        private int[] neurons_per_layer;
        Random random = new Random();

        // Network structure as array of perceptrons
        Perceptron[] perceptrons;

        public NeuroNetwork(int input_nodes, int[] neurons_per_layer, int output_nodes)
        {
            // Set parameters of network
            this.input_nodes = input_nodes;
            this.output_nodes = output_nodes;
            this.hidden_layers_count = neurons_per_layer.Length + 1; // Adds 1 becouse of output layer
            this.neurons_per_layer = neurons_per_layer.Concat(new int[] { output_nodes }).ToArray(); // Concat the out layer to hidden layer

            // Create network structure
            createNetwork();
        }

        private void createNetwork()
        {
            perceptrons = new Perceptron[neurons_per_layer.Sum()];
            int p_index = 0;
            for (int i = 0; i < hidden_layers_count; i++)
            {
                // Check if is last layer (output layer)
                bool isOutputLayer = false;
                if (i == hidden_layers_count - 1) isOutputLayer = true;

                for (int p = 0; p < neurons_per_layer[i]; p++)
                {
                    int input_nodes;
                    if (i == 0) input_nodes = this.input_nodes;
                    else input_nodes = neurons_per_layer[i - 1];
                    perceptrons[p_index++] = new Perceptron(input_nodes, random, isOutputLayer);
                }
            }
        }

        // Elaborate input signals through NeuralNetwork
        public double[] elaborate(double[] datas)
        {

            // Elaborate datas within Hidden Layers
            int p_index = 0;
            for (int i = 0; i < hidden_layers_count; i++)
            {
                for (int o = 0; o < neurons_per_layer[i]; o++)
                {
                    double[] inputs;
                    if (i == 0) inputs = datas;
                    else inputs = getPerceptronsOutputs(i - 1);
                    perceptrons[p_index++].execute_perceptron(inputs);
                }
            }

            // Return result elaborated from NeuralNetwork
            double[] result = new double[output_nodes];
            for (int i = output_nodes - 1; i >= 0; i--)
            {
                result[i] = perceptrons[p_index - i - 1].getOutput();
            }
            return result.Reverse().ToArray();
        }

        // Get perceptions outputs from prevoius layer
        private double[] getPerceptronsOutputs(int layer_id)
        {
            double[] outputs = new double[neurons_per_layer[layer_id]];
            int p_index = 0;
            for (int i = 0; i < layer_id; i++)
            {
                p_index += neurons_per_layer[i];
            }
            for (int i = 0; i < neurons_per_layer[layer_id]; i++)
            {
                outputs[i] = perceptrons[p_index++].getOutput();
            }
            return outputs;
        }


    }
}
