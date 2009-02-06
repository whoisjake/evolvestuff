using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{
    /// <summary>
    /// Defines an individual within a population.
    /// </summary>
    [Serializable]
    public class Individual
    {

        #region Fields

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value></value>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the fitness.
        /// </summary>
        /// <value></value>
        public double Fitness { get; set; }

        /// <summary>
        /// Gets or sets the generation ID.
        /// </summary>
        /// <value></value>
        public Guid GenerationID { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value></value>
        public DateTime DateCreated { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Individual"/> class.
        /// </summary>
        public Individual()
        {
            this.ID = Guid.NewGuid();
            this.DateCreated = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Individual"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="dateCreated">The date the Individual was created.</param>
        public Individual(Guid id, DateTime dateCreated)
        {
            this.ID = id;
            this.DateCreated = dateCreated;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Mates the current instance with the provide parent <see cref="Individual"/>.
        /// </summary>
        /// <param name="selectedParent"></param>
        /// <returns></returns>
        public virtual Individual Reproduce(Individual selectedParent, double mutationRate)
        {
            throw new NotImplementedException("Please implement this method on your derived instance.");
        }

        #endregion

    }
}
