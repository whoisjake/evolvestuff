using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{
    public class StrategyConfiguration
    {

        #region Fields

        /// <summary>
        /// Gets or sets a value indicating the maximum acceptable fitness level of an <see cref="Individual"/>.
        /// </summary>
        public double FitnessThreshold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="UniversalStrategy"/> should continue until it finds a fit <see cref="Individual"/>.
        /// </summary>
        public bool ContinueUntilFit { get; set; }

        /// <summary>
        /// Gets or sets the maximum iterations.
        /// </summary>
        /// <value></value>
        public int MaximumIterations { get; set; }

        /// <summary>
        /// Gets or sets the mutation rate.
        /// </summary>
        /// <value></value>
        public double MutationRate { get; set; }

        /// <summary>
        /// Gets or sets the maximum population size.
        /// </summary>
        /// <value></value>
        public int MaximumPopulation { get; set; }

        #endregion

        #region Constructor

        public StrategyConfiguration()
        {
            this.MaximumPopulation = 100;
            this.MutationRate = 0.025;
            this.MaximumIterations = 10000;
            this.ContinueUntilFit = false;
            this.FitnessThreshold = 100.0;
        }

        #endregion

    }
}
