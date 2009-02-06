using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{
    /// <summary>
    /// Describes a fitness function to evaluate <see cref="Individual"/>s.
    /// </summary>
    public class FitnessFunction<TIndividual> where TIndividual : Individual, new()
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public FitnessFunction()
        {
        }

        /// <summary>
        /// Calculates a <see cref="TIndividual"/>s fitness based on an <see cref="Environment"/>.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="individual"></param>
        /// <returns></returns>
        public virtual double CalculateFitness(SimpleEnvironment<TIndividual> environment, TIndividual individual)
        {
            return 0;
        }
    }
}
