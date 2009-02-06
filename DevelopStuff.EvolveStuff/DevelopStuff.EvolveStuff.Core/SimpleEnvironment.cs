using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{

    /// <summary>
    /// Defines a common environment where <see cref="TIndividual"/>s evolve.
    /// </summary>
    public class SimpleEnvironment<TIndividual> where TIndividual : Individual, new()
    {

        #region Fields

        private IList<TIndividual> _individuals;
        private const int MAX_POPULATION_SIZE = 100;
        private FitnessFunction<TIndividual>  _fitnessFunction;
        private ParentSelector<TIndividual> _parentSelector;
        
        /// <summary>
        /// Gets or sets the <see cref="StrategyConfiguration"/>.
        /// </summary>
        protected StrategyConfiguration StrategyConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ParentSelector<TIndividual>"/>.
        /// </summary>
        public ParentSelector<TIndividual> ParentSelector { get; set; }

        #endregion

        #region Constructor

        public SimpleEnvironment(ParentSelector<TIndividual> parentSelector, FitnessFunction<TIndividual> fitnessFunction, StrategyConfiguration config)
        {
            this.StrategyConfiguration = config;
            this.ParentSelector = parentSelector;
            this.FitnessFunction = fitnessFunction;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the maxium size of a population.
        /// </summary>
        protected virtual int MaximumPopulation
        {
            get
            {
                return this.StrategyConfiguration.MaximumPopulation;
            }
        }

        /// <summary>
        /// Gets the current <see cref="Generation"/> within the <see cref="AbstractEnvironment"/>
        /// </summary>
        public IList<TIndividual> Population
        {
            get
            {
                if (this._individuals == null)
                {
                    this._individuals = new List<TIndividual>();
                }
                return this._individuals;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FitnessFunction<TIndividual>"/>.
        /// </summary>
        public FitnessFunction<TIndividual> FitnessFunction
        {
            get
            {
                return this._fitnessFunction;
            }
            set
            {
                this._fitnessFunction = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get's the most fit <see cref="TIndividual"/>.
        /// </summary>
        /// <returns></returns>
        public TIndividual GetMostFitIndividual()
        {
            IList<TIndividual> sortedIndividuals = this.GetIndividualsSortedByFitness();

            if (sortedIndividuals.Count > 0)
            {
                return sortedIndividuals[sortedIndividuals.Count - 1];
            }

            return null;
        }

        /// <summary>
        /// Gets the <see cref="TIndividual"/>s sorted by fitness.
        /// </summary>
        /// <returns></returns>
        public IList<TIndividual> GetIndividualsSortedByFitness()
        {
            List<TIndividual> sorted = new List<TIndividual>(this.Population);
            sorted.Sort(new GenericFitnessComparer<TIndividual>());
            return sorted;
        }

        /// <summary>
        /// Returns a collection of the most recently generated <see cref="TInvdividual"/>s.
        /// </summary>
        /// <returns></returns>
        public IList<TIndividual> GetNewIndividuals()
        {
            List<TIndividual> newIndividuals = new List<TIndividual>();

            foreach (TIndividual individual in this.Population)
            {
                if (individual.GenerationID == Guid.Empty)
                {
                    newIndividuals.Add(individual);
                }
            }

            return newIndividuals;
        }

        /// <summary>
        /// Trims the population.
        /// </summary>
        public void TrimPopulation()
        {
            List<TIndividual> individualsToRemove = new List<TIndividual>();
            IList<TIndividual> sorted = this.GetIndividualsSortedByFitness();

            for (int i = 0; i < (this.Population.Count/4); i++)
            {
                individualsToRemove.Add(sorted[i]);
            }

            foreach (TIndividual individual in individualsToRemove)
            {
                this.RemoveIndividual(individual);
            }
        }

        /// <summary>
        /// Triggers the population to reproduce.
        /// </summary>
        public void Reproduce()
        {
            int numberToReproduce = this.MaximumPopulation - this.Population.Count;

            for (int i = numberToReproduce; i > 0; i--)
            {
                TIndividual parentA = this.ParentSelector.SelectMate(this);
                TIndividual parentB = this.ParentSelector.SelectMate(this);

                Individual newIndividual = parentA.Reproduce(parentB, 0);

                this.AddIndividual((TIndividual)newIndividual);
            }
        }

        /// <summary>
        /// Evaluates the population.
        /// </summary>
        public void EvaluatePopulation()
        {
            foreach (TIndividual individual in this.Population)
            {
                individual.Fitness = this.FitnessFunction.CalculateFitness(this, individual);
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public virtual void Initialize()
        {
            this.InitializeFitnessFunction();
            this.ClearPopulation();
            this.GenerateInitialPopulation();
        }

        /// <summary>
        /// Initializes the <see cref="FitnessFunction"/>
        /// </summary>
        protected virtual void InitializeFitnessFunction()
        {
            
        }

        /// <summary>
        /// Generates an initial population of <see cref="TIndividual"/>s.
        /// </summary>
        protected virtual void GenerateInitialPopulation()
        {
            for (int i = 0; i < this.MaximumPopulation; i++)
            {
                this.AddIndividual(new TIndividual());
            }
        }

        /// <summary>
        /// Clears the population.
        /// </summary>
        public void ClearPopulation()
        {
            this.Population.Clear();
        }

        /// <summary>
        /// Removes an <see cref="TIndividual"/> from the <see cref="AbstractEnvironment"/>.
        /// </summary>
        /// <param name="individual"></param>
        public void RemoveIndividual(TIndividual individual)
        {
            if (this.Population.Contains(individual))
            {
                this.Population.Remove(individual);
            }
        }

        /// <summary>
        /// Adds an <see cref="TIndividual"/> to the <see cref="AbstractEnvironment"/>.
        /// </summary>
        /// <param name="individual"></param>
        public void AddIndividual(TIndividual individual)
        {
            if (!this.Population.Contains(individual))
            {
                this.Population.Add(individual);
            }
        }

        #endregion

    }
}
