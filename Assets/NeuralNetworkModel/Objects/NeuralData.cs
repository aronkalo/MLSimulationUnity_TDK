using System.Collections.Generic;

namespace Assets.Neural_Network.Objects
{
    public class NeuralData
    {
        public NeuralData()
        {
            Data = new List<double[]>();
        }
        public List<double[]> Data { get; internal set; }
    }
}