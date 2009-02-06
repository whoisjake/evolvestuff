using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{
    public class StrategyConfiguration
    {

        #region Fields

        private int _maximumPopulation = 100;
        private double _mutationRate = 0.025;
        private int _maximumIterations = 10000;
        private bool _continueUntilFit = false;
        private double _fitnessThreshold = 100.0;

        #endregion

        #region Constructor

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating the maximum acceptable fitness level of an <see cref="Individual"/>.
        /// </summary>
        public double FitnessThreshold
        {
            get { return _fitnessThreshold; }
            set { _fitnessThreshold = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="UniversalStrategy"/> should continue until it finds a fit <see cref="Individual"/>.
        /// </summary>
        public bool ContinueUntilFit
        {
            get { return _continueUntilFit; }
            set { _continueUntilFit = value; }
        }

        /// <summary>
        /// Gets or sets the maximum iterations.
        /// </summary>
        /// <value></value>
        public int MaximumIterations
        {
            get { return _maximumIterations; }
            set { _maximumIterations = value; }
        }

        /// <summary>
        /// Gets or sets the mutation rate.
        /// </summary>
        /// <value></value>
        public double MutationRate
        {
            get { return _mutationRate; }
            set { _mutationRate = value; }
        }

        /// <summary>
        /// Gets or sets the maximum population size.
        /// </summary>
        /// <value></value>
        public int MaximumPopulation
        {
            get { return _maximumPopulation; }
            set { _maximumPopulation = value; }
        }

        #endregion

    }
}
