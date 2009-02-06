using System;
using System.ComponentModel;

namespace DevelopStuff.EvolveStuff.Core
{
    /// <summary>
    /// Defines an event handler used to signal a change to the state of the application.
    /// </summary>
    public delegate void GenerationEventHandler<TIndividual>(object sender, GenerationEventArgs<TIndividual> e) where TIndividual : Individual, new();

    /// <summary>
    /// <see cref="CancelEventArgs"/> for handling events dealing with a <see cref="Generation"/>
    /// </summary>
    public class GenerationEventArgs<TIndividual> : CancelEventArgs where TIndividual : Individual, new()
    {

        #region Fields

        private Generation<TIndividual> _generation;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="generation"></param>
        public GenerationEventArgs(Generation<TIndividual> generation)
        {
            this._generation = generation;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="Generation"/>
        /// </summary>
        public Generation<TIndividual> Generation
        {
            get
            {
                return this._generation;
            }
        }

        #endregion

    }
}