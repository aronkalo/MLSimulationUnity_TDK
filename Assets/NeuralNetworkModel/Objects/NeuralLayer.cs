using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Neural_Network.Objects
{
    class NeuralLayer
    {
        public List<Neuron> Neurons { get; set; }

        public double Weight { get; set; }

        public NeuralLayer(int neuronCount, double initialWeight)
        {
            Neurons = new List<Neuron>();
            for (int i = 0; i < neuronCount; i++)
            {
                Neurons.Add(new Neuron());
            }
            Weight = initialWeight;
        }

        public void Compute(double learningRate, double delta)
        {
            foreach (var neuron in Neurons)
            {
                neuron.Compute(learningRate, delta);
            }
        }

        internal void Forward()
        {
            foreach (var Neuron in Neurons)
            {
                Neuron.Fire();
            }
        }

        internal void Optimize(float learningRate, int delta)
        {
            Weight += learningRate * delta;
            foreach (var Neuron in Neurons)
            {
                Neuron.UpdateWeights(Weight);
            }
        }
    }
}
