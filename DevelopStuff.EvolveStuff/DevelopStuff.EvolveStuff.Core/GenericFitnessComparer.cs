using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{
    public class GenericFitnessComparer<TIndividual> : IComparer<TIndividual> where TIndividual : Individual, new()
    {
        #region IComparer<TIndividual> Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        /// </returns>
        public int Compare(TIndividual x, TIndividual y)
        {
            return x.Fitness.CompareTo(y.Fitness);
        }

        #endregion
    }
}
