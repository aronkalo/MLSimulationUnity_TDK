using Assets.Neural_Network.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Neural_Network
{
    class NeuralNetwork
    {
        public List<NeuralLayer> Layers { get; set; }

        public double Accuracy { get; private set; }

        public NeuralNetwork()
        {
            Layers = new List<NeuralLayer>();
        }

        public void AddLayer(NeuralLayer layer)
        {
            int dendriteCount = 1;
            if (Layers.Count > 0)
            {
                dendriteCount = Layers.Last().Neurons.Count;
            }
            foreach (var element in layer.Neurons)
            {
                for (int i = 0; i < dendriteCount; i++)
                {
                    element.Nerves.Add(new Nerve());
                }
            }
        }

        public void Build()
        {
            int i = 0;
            foreach (var layer in Layers)
            {
                if (i >= Layers.Count - 1)
                {
                    break;
                }
                var nextLayer = Layers[i + 1];
                CreateNetwork(layer, nextLayer);
                i++;
            }
        }

        public void Train(NeuralData InputData, NeuralData referenceOutput, int iterations, double learningRate = 0.1)
        {
            int epoch = 1;
            while (iterations >= epoch)
            {
                NeuralLayer inputLayer = Layers[0];
                List<double> outputs = new List<double>();
                for (int i = 0; i < InputData.Data.Count; i++)
                {
                    for (int y = 0; y < InputData.Data[i].Length; y++)
                    {
                        inputLayer.Neurons[y]
                            .OutPulse.Value = InputData.Data[i][y];
                    }
                    ComputeOutput();
                    outputs.Add(Layers.Last()
                        .Neurons.First().OutPulse.Value);
                }
                double accuracy = 0;
                int y_counter = 0;
                outputs.ForEach((x) =>
                {
                    if (x == referenceOutput.Data[y_counter].First())
                    {
                        accuracy++;
                    }
                    y_counter++;
                });
                Accuracy = accuracy / y_counter;
                OptimizeWeights(accuracy / y_counter);
                epoch++;
            }
        }

        private void OptimizeWeights(double accuracy)
        {
            float lr = 0.1f;
            if (accuracy == 1)
            {
                return;
            }
            if (accuracy > 1)
            {
                lr = -lr;
            }
            foreach (var Layer in Layers)
            {
                Layer.Optimize(lr, 1);
            }
        }

        private void ComputeOutput()
        {
            bool first = true;
            foreach (var Layer in Layers)
            {
                if (first)
                {
                    first = true;
                    continue;
                }
                Layer.Forward();
            }
        }

        private void CreateNetwork(NeuralLayer connectingFrom, NeuralLayer connectingTo)
        {
            foreach (var to in connectingTo.Neurons)
            {
                foreach (var from in connectingFrom.Neurons)
                {
                    to.Nerves.Add(new Nerve() {  InPulse = to.OutPulse, Weight = connectingTo.Weight });
                }
            }
        }
    }
}
