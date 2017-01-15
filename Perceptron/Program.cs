using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Tuple<double[], double>>();

            data.Add(new Tuple<double[], double>(new double[] { 1.5, 2.0 }, 0));
            data.Add(new Tuple<double[], double>(new double[] { 2.0, 3.5 }, 0));
            data.Add(new Tuple<double[], double>(new double[] { 3.0, 5.0 }, 0));
            data.Add(new Tuple<double[], double>(new double[] { 3.5, 2.5 }, 0));
            data.Add(new Tuple<double[], double>(new double[] { 4.5, 5.0 }, 1));
            data.Add(new Tuple<double[], double>(new double[] { 5.0, 7.0 }, 1));
            data.Add(new Tuple<double[], double>(new double[] { 5.5, 8.0 }, 1));
            data.Add(new Tuple<double[], double>(new double[] { 6.0, 6.0 }, 1));

            //var neuron = new SingleNeuron(new LinearUnit());
            var neuron = new SingleNeuron(new Sigmoid());
            neuron.Initialize(2, 0.1);

            neuron.Train(data, 500);

            var test1 = neuron.Evaluate(new double[] { 3.0, 4.0 }); // ~ 0
            var test2 = neuron.Evaluate(new double[] { 0.0, 1.0 }); // ~ 0
            var test3 = neuron.Evaluate(new double[] { 2.0, 5.0 }); // ~ 0
            var test4 = neuron.Evaluate(new double[] { 5.0, 6.0 }); // ~ 1
            var test5 = neuron.Evaluate(new double[] { 9.0, 9.0 }); // ~ 1
            var test6 = neuron.Evaluate(new double[] { 4.0, 6.0 }); // ~ 1
            Console.Write("{0} {1} {2} {3} {4} {5}", test1, test2, test3, test4, test5, test6);
            Console.Read();
        }
    }
}
