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

        private Guid _id;
        private double _fitness;
        private Guid _generationID;
        private DateTime _dateCreated;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Individual"/> class.
        /// </summary>
        public Individual()
        {
            this._id = Guid.NewGuid();
            this._dateCreated = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Individual"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="dateCreated">The date the Individual was created.</param>
        public Individual(Guid id, DateTime dateCreated)
        {
            this._id = id;
            this._dateCreated = dateCreated;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value></value>
        public DateTime DateCreated
        {
            get
            {
                return this._dateCreated;
            }
            set
            {
                this._dateCreated = value;
            }
        }

        /// <summary>
        /// Gets or sets the generation ID.
        /// </summary>
        /// <value></value>
        public Guid GenerationID
        {
            get
            {
                return this._generationID;
            }
            set
            {
                this._generationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the fitness.
        /// </summary>
        /// <value></value>
        public double Fitness
        {
            get
            {
                return this._fitness;
            }
            set
            {
                this._fitness = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value></value>
        public Guid ID
        {
            get 
            { 
                return this._id; 
            }
            set
            { 
                this._id = value; 
            }
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
