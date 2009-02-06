using System;

namespace DevelopStuff.EvolveStuff.Core
{
    /// <summary>
    /// Defines a mate selection process.
    /// </summary>
    public class ParentSelector<TIndividual> where TIndividual : Individual, new()
    {

        #region Default Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ParentSelector()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Randomly selects a single parent (<see cref="TIndividual"/>).
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <returns></returns>
        public virtual TIndividual SelectMate(SimpleEnvironment<TIndividual> environment)
        {
            Random randomGenerator = new Random((int)System.DateTime.Now.Ticks);

            TIndividual parent = environment.Population[randomGenerator.Next(0, environment.Population.Count)];

            return parent;
        }

        #endregion

    }
}
