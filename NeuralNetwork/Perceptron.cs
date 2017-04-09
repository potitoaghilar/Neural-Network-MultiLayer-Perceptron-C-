using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Perceptron
    {

        protected double[] weights;
        protected double bias;
        private Random random = new Random();
        
        protected double output;

        public Perceptron(int input_nodes)
        {
            // Initialize perceptron with weights and bias to random
            double[] inputs = new double[input_nodes];

            // Randomize input weights
            for (int i = 0; i < input_nodes; i++)
            {
                inputs[i] = random.NextDouble();
            }

            init(inputs, random.NextDouble());
        }
        public Perceptron(double[] weights, double bias)
        {
            // Initialize perceptron with setted weights and bias
            init(weights, bias);
        }
        private void init(double[] weights, double bias)
        {
            this.weights = weights;
            this.bias = bias;
        }

        // Set/Get weights
        public void setWeights(double[] weights)
        {
            this.weights = weights;
        }
        public double[] getWeights()
        {
            return weights;
        }

        // Set/Get bias
        public void setBias(double bias)
        {
            this.bias = bias;
        }
        public double getBias()
        {
            return bias;
        }

        // Main perceptron elaborator
        public void execute_perceptron(double[] input)
        {
            output = sigmoid(dot_product(input, weights) + bias);
        }

        public double getOutput()
        {
            double output = this.output;
            this.output = 0;
            return output;
        }

        // Dot product
        private double dot_product(double[] vector1, double[] vector2)
        {
            double result = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                for (int o = 0; o < vector2.Length; o++)
                {
                    result += vector1[i] * vector2[o];
                }
            }
            return result;
        }

        // Activator functions
        private double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
        private int binary(double x)
        {
            if (x >= 0) return 1;
            else return 0;
        }
    }
}
