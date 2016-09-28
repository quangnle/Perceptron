﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public interface IActivationFunc
    {
        double Evaluate(double input);
        double MinSquaredError(double input, double target);
    }
}
