using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class LinearUnit : IActivationFunc
    {
        public double Evaluate(double input)
        {
            return input > 0.5 ? 1 : 0;
        }

        public double MinSquaredError(double input, double target)
        {
            return (target - input);
        }
    }
}
