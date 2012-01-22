using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace DevelopStuff.EvolveStuff.Core
{
    /// <summary>
    /// Defines a <see cref="Generation"/> within an <see cref="AbstractEnvironment"/>
    /// </summary>
    [Serializable]
    public class Generation<TIndividual> : IEnumerable<TIndividual> where TIndividual : Individual, new()
    {

        #region Fields

        private Guid _id;
        private IList<TIndividual> _individuals;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <remarks>Used for construction of a new <see cref="Generation"/></remarks>
        /// <param name="individuals"></param>
        public Generation(IList<TIndividual> individuals)
        {
            _individuals = individuals;
            _id = Guid.NewGuid();
            this.SetupIndividuals();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <remarks>Used for archiving or retrieval of a previously created <see cref="Generation"/></remarks>
        /// <param name="individuals"></param>
        /// <param name="id"></param>
        public Generation(Guid id, IList<TIndividual> individuals)
        {
            _id = id;
            _individuals = individuals;
            this.SetupIndividuals();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the count of <see cref="Individual"/>s within the <see cref="Generation"/>.
        /// </summary>
        public int Count
        {
            get
            {
                if (this.Individuals == null)
                {
                    return 0;
                }

                return this.Individuals.Count;
            }
        }

        /// <summary>
        /// Gets the <see cref="Guid"/> ID of the <see cref="Generation"/>.
        /// </summary>
        public Guid ID
        {
            get
            {
                return this._id;
            }
        }

        /// <summary>
        /// Indexor for the <see cref="Generation"/>
        /// </summary>
        public TIndividual this[int index]
        {
            get
            {
                return this.Individuals[index];
            }
            set
            {
                this.Individuals[index] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TIndividual"/>s of the <see cref="Generation"/>.
        /// </summary>
        protected internal IList<TIndividual> Individuals
        {
            get
            {
                if (_individuals == null)
                {
                    _individuals = new List<TIndividual>();
                }

                return _individuals;
            }
            set
            {
                this._individuals = value;
            }
        }

        #endregion

        #region Methods
		
		/// <summary>
		/// Finds the best fit <see cref="TIndividual"/>.
		/// </summary>
		public TIndividual BestFit()
		{
			TIndividual bestSoFar = null;
			double bestFit = double.MinValue;
			
			foreach(TIndividual indv in this.Individuals)
			{
				if (indv.Fitness > bestFit)
				{
					bestSoFar = indv;
					bestFit = indv.Fitness;
				}
			}
			
			return bestSoFar;
		}

        /// <summary>
        /// Takes each individual and performs an initial setup.
        /// </summary>
        private void SetupIndividuals()
        {
            foreach (TIndividual individual in this.Individuals)
            {
                individual.GenerationID = this.ID;
            }
        }

        /// <summary>
        /// Returns whether the <see cref="Generation"/> contains a specific <see cref="TIndividual"/>.
        /// </summary>
        /// <param name="individual"></param>
        /// <returns></returns>
        public bool Contains(TIndividual individual)
        {
            return this.Individuals.Contains(individual);
        }

        /// <summary>
        /// Clears the <see cref="Generation"/>.
        /// </summary>
        public void Clear()
        {
            this.Individuals.Clear();
        }

        #endregion


        #region IEnumerable<TIndividual> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<TIndividual> GetEnumerator()
        {
            foreach(TIndividual individual in this.Individuals)
            {
                yield return individual;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
