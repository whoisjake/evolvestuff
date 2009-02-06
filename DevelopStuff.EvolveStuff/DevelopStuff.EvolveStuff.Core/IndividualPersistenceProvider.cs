using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopStuff.EvolveStuff.Core
{
    public class IndividualPersistenceProvider<TIndividual> where TIndividual : Individual, new()
    {
        public virtual TIndividual RetriveIndividual(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual bool PersistIndividual(TIndividual individual)
        {
            throw new NotImplementedException();
        }

        public virtual Generation<TIndividual> RetrieveGeneration(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual bool PersistGeneration(Generation<TIndividual> generation)
        {
            throw new NotImplementedException();
        }

    }
}
