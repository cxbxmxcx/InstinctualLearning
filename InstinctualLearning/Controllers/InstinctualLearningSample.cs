using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Reinsertions;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstinctualLearning
{
    public class InstrinctualLearningSample<Environment> : ISampleController 
        where Environment : IEnvironment
    {
        InstinctualLearningFitness<Environment> m_fitness;
        private int m_maxOperations;
        private List<InstinctualLearningInput> m_inputs;

        public void ConfigGA(GeneticAlgorithm ga)
        {
            ga.CrossoverProbability = 0.1f;
            ga.MutationProbability = 0.4f;
            ga.Reinsertion = new ElitistReinsertion();
        }

        /// <summary>
        /// Creates the chromosome.
        /// </summary>
        /// <returns>The sample chromosome.</returns>
        public IChromosome CreateChromosome()
        {
            return new InstinctualLearningChromosome(m_fitness.AvailableOperations, m_maxOperations);
        }

        /// <summary>
        /// Creates the fitness.
        /// </summary>
        /// <returns>The fitness.</returns>
        public IFitness CreateFitness()
        {
            return m_fitness;
        }

        /// <summary>
        /// Creates the crossover.
        /// </summary>
        /// <returns>The crossover.</returns>
        public ICrossover CreateCrossover()
        {
            return new ThreeParentCrossover();
        }

        /// <summary>
        /// Creates the mutation.
        /// </summary>
        /// <returns>The mutation.</returns>
        public IMutation CreateMutation()
        {
            return new UniformMutation(true);
        }

        /// <summary>
        /// Creates the selection.
        /// </summary>
        /// <returns>The selection.</returns>
        public ISelection CreateSelection()
        {
            return new EliteSelection();
        }

        /// <summary>
        /// Creates the termination.
        /// </summary>
        /// <returns> 
        /// The termination.
        /// </returns>
        public ITermination CreateTermination()
        {
            return new FitnessThresholdTermination(0.0);
        }

        /// <summary>
        /// Draws the specified best chromosome.
        /// </summary>
        /// <param name="bestChromosome">The best chromosome.</param>
        public void Draw(IChromosome bestChromosome)
        {
            var best = bestChromosome as InstinctualLearningChromosome;

            foreach (var input in m_inputs)
            {
                Console.WriteLine("{0} = {1}", string.Join(", ", input.Arguments), input.ExpectedResult);
            }

           
            Console.WriteLine("Max operations: {0}", m_maxOperations);
            Console.WriteLine("Function: {0}", best.BuildFunction());
            Console.WriteLine("Path followed: {0}", InstinctualLearningChromosome.Best);
        }

        public void Initialize()
        {
            Console.WriteLine("Initializing GeneticTensorFlowLearning by Evolution.");

            Console.WriteLine("Function arguments and expected result: arg1,arg2=expected result.");
            Console.WriteLine("Sample1: 1,2,3=6");
            Console.WriteLine("Sample2: 2,3,4=24");
            Console.WriteLine("When finish, type ENTER to start the GA.");

            m_inputs = new List<InstinctualLearningInput>();
            do
            {
                var parts = Console.ReadLine().Split('=');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Max number of operations?");
                    m_maxOperations = Convert.ToInt32(Console.ReadLine());

                    break;
                }

                var arguments = parts[0].Split(',');

                var input = new InstinctualLearningInput(
                    arguments.Select(a => Convert.ToDouble(a)).ToList(),
                    Convert.ToDouble(parts[1]));

                m_inputs.Add(input);
            }
            while (true);

            m_fitness = new InstinctualLearningFitness<Environment>(m_inputs.ToArray());
        }
    }
}
