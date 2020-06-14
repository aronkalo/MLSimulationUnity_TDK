using Assets.Neural_Network;
using Assets.Neural_Network.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    static class ExTraining
    {
        public static void DoTraining()
        {
            NeuralNetwork TestNetwork = new NeuralNetwork();
            TestNetwork.AddLayer(new NeuralLayer(3, 0.1));
            TestNetwork.AddLayer(new NeuralLayer(1, 0.1));
            TestNetwork.Build();
            NeuralData InputData = new NeuralData();
            InputData.Data.Add(new double[] { 0,0,0 });
            InputData.Data.Add(new double[] { 1,0,0 });
            InputData.Data.Add(new double[] { 0,1,0 });
            InputData.Data.Add(new double[] { 1,1,0 });
            InputData.Data.Add(new double[] { 0,0,1 });
            InputData.Data.Add(new double[] { 1,0,1 });
            InputData.Data.Add(new double[] { 0,1,1 });
            InputData.Data.Add(new double[] { 1,1,1 });
            NeuralData RefOutput = new NeuralData();
            RefOutput.Data.Add(new double[] { 0 });
            RefOutput.Data.Add(new double[] { 0 });
            RefOutput.Data.Add(new double[] { 0 });
            RefOutput.Data.Add(new double[] { 1 });
            RefOutput.Data.Add(new double[] { 0 });
            RefOutput.Data.Add(new double[] { 1 });
            RefOutput.Data.Add(new double[] { 1 });
            RefOutput.Data.Add(new double[] { 1 });
            TestNetwork.Train(InputData, RefOutput, iterations: 10, learningRate: 0.1);
            Console.WriteLine($"CURRENT ACCURACY: {TestNetwork.Accuracy}");
        }
    }
}
