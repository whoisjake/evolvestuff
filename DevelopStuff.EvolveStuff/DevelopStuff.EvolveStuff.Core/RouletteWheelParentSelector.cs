using System;

namespace DevelopStuff.EvolveStuff.Core
{
    /// <summary>
    /// Defines an <see cref="IParentSelector"/> for selecting parents (<see cref="Individual"/>) using a roulette wheel.
    /// </summary>
    public class RouletteWheelParentSelector<TIndividual> : ParentSelector<TIndividual> where TIndividual : Individual, new()
    {

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RouletteWheelParentSelector()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects a single parent (<see cref="TIndividual"/>) using a roulette wheel.
        /// </summary>
        /// <remarks>This requires the population to be sorted by fitness.</remarks>
        /// <param name="environment">The environment.</param>
        /// <returns></returns>
        public override TIndividual SelectMate(SimpleEnvironment<TIndividual> environment)
        {
            if ((environment == null)
                || (environment.Population == null)
                || (environment.Population.Count < 1))
            {
                throw new ArgumentException("environment", "The environment should be populated.");
            }

            double totalFitness = 0;

            foreach (TIndividual individual in environment.Population)
            {
                totalFitness += individual.Fitness;
            }

            Random random = new Random(System.DateTime.Now.Millisecond);

            double goal = random.Next(0, (int)totalFitness);
            double sumSoFar = 0;

            TIndividual selectedMate = null;

            foreach (TIndividual individual in environment.Population)
            {
                sumSoFar += individual.Fitness;
                selectedMate = individual;

                if (sumSoFar > goal)
                {
                    break;
                }
            }

            return selectedMate;
        }

        #endregion

    }
}
