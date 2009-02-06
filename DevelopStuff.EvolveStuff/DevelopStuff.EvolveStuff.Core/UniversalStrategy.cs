using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{

    /// <summary>
    /// Defines the universal evolutionary strategy.
    /// </summary>
    /// <remarks>Use this class as a core instance to execute the strategy.</remarks>
    public class UniversalStrategy<TIndividual, TFitnessFunction>
        where TIndividual : Individual, new()
        where TFitnessFunction : FitnessFunction<TIndividual>, new()
    {

        #region Events

        public event GenerationEventHandler<TIndividual> GenerationStarted;
        public event GenerationEventHandler<TIndividual> GenerationEvolved;

        #endregion

        #region Fields
        /// <summary>
        /// Gets or sets the <see cref="SimpleEnvironment"/>.
        /// </summary>
        public SimpleEnvironment<TIndividual> Environment { get; set; }
        private IList<Generation<TIndividual>> _generations;

        /// <summary>
        /// Gets or sets the <see cref="StrategyConfiguration"/>.
        /// </summary>
        public StrategyConfiguration StrategyConfiguration { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UniversalStrategy(StrategyConfiguration config)
        {
            this.StrategyConfiguration = config;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UniversalStrategy()
        {
            this.StrategyConfiguration = new StrategyConfiguration();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a list of <see cref="Generation<TIndividual>"/>
        /// </summary>
        public IList<Generation<TIndividual>> Generations
        {
            get
            {
                if (this._generations == null)
                {
                    if (this.StrategyConfiguration.ContinueUntilFit)
                    {
                        this._generations = new List<Generation<TIndividual>>();
                    }
                    else
                    {
                        this._generations = new List<Generation<TIndividual>>(this.StrategyConfiguration.MaximumIterations);
                    }
                }

                return this._generations;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the strategy should continue
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        protected virtual bool ShouldContinue(Generation<TIndividual> generation)
        {
            if (this.StrategyConfiguration.ContinueUntilFit)
            {
                TIndividual mostFit = this.Environment.GetMostFitIndividual();
                return (mostFit != null) && (mostFit.Fitness < this.StrategyConfiguration.FitnessThreshold);
            }

            return this.Generations.Count < this.StrategyConfiguration.MaximumIterations;
        }

        /// <summary>
        /// The main evolutionary algorithm.
        /// </summary>
        /// <remarks>This will intialize a generation and run until the conditions are met.</remarks>
        public void Evolve()
        {

            this.InitializeEnvirontment();

            bool shouldContinue = true;

            while(shouldContinue)
            {
                this.EvaluateIndividuals();
                this.TrimIndividuals();
                Generation<TIndividual> generation = new Generation<TIndividual>(this.Environment.GetNewIndividuals());
                this.Generations.Add(generation);
                this.OnGenerationEvolved(new GenerationEventArgs<TIndividual>(generation));
                this.Reproduce();
                this.OnGenerationCreated(new GenerationEventArgs<TIndividual>(generation));
                shouldContinue = this.ShouldContinue(generation);
            }

            this.EvaluateIndividuals();

        }

        /// <summary>
        /// Creates a child population.
        /// </summary>
        /// <returns></returns>
        protected virtual void Reproduce()
        {
            this.Environment.Reproduce();
        }

        /// <summary>
        /// Trims a population. Simulates individuals that die off and don't fit the natural selection.
        /// </summary>
        protected virtual void TrimIndividuals()
        {
            this.Environment.TrimPopulation();
        }

        /// <summary>
        /// Evaluates a generation.
        /// </summary>
        protected virtual void EvaluateIndividuals()
        {
            this.Environment.EvaluatePopulation();
        }

        /// <summary>
        /// Raises the <see cref="GenerationEvolved"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnGenerationEvolved(GenerationEventArgs<TIndividual> e)
        {
            if (this.GenerationEvolved != null)
            {
                this.GenerationEvolved(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="GenerationCreated"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnGenerationCreated(GenerationEventArgs<TIndividual> e)
        {
            if (this.GenerationStarted != null)
            {
                this.GenerationStarted(this, e);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="IMateSelector"/> for the <see cref="UniversalStrategy"/>
        /// </summary>
        protected virtual void InitializeEnvirontment()
        {
            this.Environment = new SimpleEnvironment<TIndividual>(new RouletteWheelParentSelector<TIndividual>(), new TFitnessFunction(), this.StrategyConfiguration);
            this.Environment.Initialize();
        }

        #endregion

    }

}
