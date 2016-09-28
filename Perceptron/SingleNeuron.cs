using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class SingleNeuron
    {
        private int _nInputs = 0;
        private double _learningRate = 0.0;
        private IActivationFunc _activation = null;
        public double[] Weights { get; set; }

        public SingleNeuron()
        {
            _activation = new LinearUnit();
        }

        public SingleNeuron(IActivationFunc activation)
        {
            _activation = activation;
        }

        public void Initialize(int numberOfInputs, double learningRate)
        {
            _nInputs = numberOfInputs;
            _learningRate = learningRate;
            Weights = new double[_nInputs + 1];

            Random rnd = new Random();
            for (int i = 0; i < _nInputs + 1; i++)
            {
                Weights[i] = rnd.NextDouble();
            }
        }

        public void TrainOnce(double[] input, double target)
        {
            if (input.Length != _nInputs)
                throw new Exception("Invalid training data.");

            var s = Sum(input);

            double error = _activation.MinSquaredError(s, target);

            Weights[0] += _learningRate * error;
            for (int i = 0; i < _nInputs; i++)
            {
                Weights[i + 1] += _learningRate * error * input[i];
            }
        }

        public void Train(List<Tuple<double[], double>> data, int nTimes)
        {
            for (int n = 0; n < nTimes; n++)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    TrainOnce(data[i].Item1, data[i].Item2);
                }
            }
        }

        private double Sum(double[] input)
        {
            double output = Weights[0];
            for (int i = 0; i < _nInputs; i++)
            {
                output += input[i] * Weights[i + 1];
            }

            return output;
        }

        public double Evaluate(double[] input)
        {
            return _activation.Evaluate(Sum(input));
        }
    }
}
