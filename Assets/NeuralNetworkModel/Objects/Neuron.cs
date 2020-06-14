using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Neural_Network.Objects
{
    class Neuron
    {
        public List<Nerve> Nerves { get; set; }

        public Impulse OutPulse { get; set; }

        private double Weight;
        public Neuron()
        {
            Nerves = new List<Nerve>();
            OutPulse = new Impulse();
        }

        public void Fire()
        {
            OutPulse.Value = Sum();
            OutPulse.Value = Activation(OutPulse.Value);
        }

        public void Compute(double learningRate, double delta)
        {
            Weight += learningRate * delta;
            foreach (var Nerve in Nerves)
            {
                Nerve.Weight = Weight;
            }
        }

        private double Activation(double input)
        {
            double threshold = 1;
            return input >= threshold ? 0 : threshold;
        }

        private double Sum()
        {
            double computeValue = 0.0f;
            foreach (var Nerve in Nerves)
            {
                computeValue += Nerve.InPulse.Value * Nerve.Weight;
            }

            return computeValue;
        }

        internal void UpdateWeights(double newWeights)
        {
            foreach (var Nerve in Nerves)
            {
                Nerve.Weight = newWeights;
            }
        }
    }
}
