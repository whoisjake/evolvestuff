using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopStuff.EvolveStuff.Core;
using DevelopStuff.EvolveStuff.Examples.BitBug;

namespace DevelopStuff.EvolveStuff.Examples.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversalStrategy<Bug, BitBugFitnessFunction> evolver = new UniversalStrategy<Bug, BitBugFitnessFunction>();
            evolver.Evolve();
            Generation<Bug> bugs = evolver.Generations.Last<Generation<Bug>>();

            foreach (Bug b in bugs)
            {
                StringBuilder sb = new StringBuilder();
                foreach (int i in b.Values)
                {
                    sb.Append(i);
                }
                Console.WriteLine("Bug #" + b.ID.ToString() + " - " + sb.ToString() + " Fitness: " + b.Fitness.ToString());
            }

            Console.WriteLine("Done Evolving.");
            Console.ReadLine();
        }
    }
}