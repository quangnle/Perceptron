using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class Sigmoid : IActivationFunc  
    {
        public double Evaluate(double input)
        {
            return 1.0 / (1 + Math.Exp(input * -1));
        }

        public double ComputeError(double input, double target)
        {
            var s = Evaluate(input);
            return (target - s) * s * (1 - s);
        }
    }
}
