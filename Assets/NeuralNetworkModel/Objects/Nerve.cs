using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Neural_Network.Objects
{
    class Nerve
    {
        public Nerve(bool active = true)
        {
            Adjustable = active;
        }
        public Impulse InPulse { get; set; }

        public double Weight { get; set; }

        public bool Adjustable;
    }
}
