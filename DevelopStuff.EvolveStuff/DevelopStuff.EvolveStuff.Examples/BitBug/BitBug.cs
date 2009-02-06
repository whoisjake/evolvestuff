using System;
using System.Collections.Generic;
using System.Text;
using DevelopStuff.EvolveStuff.Core;

namespace DevelopStuff.EvolveStuff.Examples.BitBug
{
    public class BitBug : Individual
    {
        private int[] _values;
        private static Random _random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BitBug"/> class.
        /// </summary>
        public BitBug()
            : base()
        {
            _values = new int[16];
            this.RandomizeValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BitBug"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="values">The values.</param>
        /// <param name="dateCreated">The date created.</param>
        public BitBug(Guid id, int[] values, DateTime dateCreated)
            : base(id, dateCreated)
        {
            _values = values;
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value></value>
        public int[] Values
        {
            get { return _values; }
            set { _values = value; }
        }

        /// <summary>
        /// Randomizes the values.
        /// </summary>
        private void RandomizeValues()
        {
            for (int i = 0; i < 8; i++)
            {
                this.Values[i] = (_random.Next(0, 100000) < 50000) ? 0 : 1;
                this.Values[15 - i] = (_random.Next(0, 100000) < 50000) ? 0 : 1;
            }
        }

        /// <summary>
        /// Mates the current instance with the provide parent <see cref="Individual"/>.
        /// </summary>
        /// <param name="selectedParent"></param>
        /// <param name="mutationRate"></param>
        /// <returns></returns>
        public override Individual Reproduce(Individual selectedParent, double mutationRate)
        {
            int[] childValues = new int[16];

            for (int i = 0; i < 8; i++)
            {
                childValues[i] = this.Values[i];
                childValues[15 - i] = ((BitBug)selectedParent).Values[15 - i];
            }

            BitBug child = new BitBug();
            child.Values = childValues;

            if (_random.Next(0, 100) <= (mutationRate * 100))
            {
                int bitToChange = _random.Next(0, 15);
                child.Values[bitToChange] = (child.Values[bitToChange] == 1) ? 0 : 1;
            }

            return child;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
            {
                sb.Append(this.Values[i]);
            }
            return string.Format("{0} : {1} : {2} : {3}", this.ID.ToString(), this.DateCreated.ToString("d"), sb.ToString(), this.Fitness.ToString());
        }
    }
}
