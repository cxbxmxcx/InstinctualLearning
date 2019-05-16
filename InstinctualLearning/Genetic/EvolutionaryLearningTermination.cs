using GeneticSharp.Domain;
using GeneticSharp.Domain.Terminations;

namespace InstinctualLearning
{
    public class EvolutionaryLearningTermination : ITermination
    {
        private int v;

        public EvolutionaryLearningTermination(int v)
        {
            this.v = v;
        }

        public bool HasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            throw new System.NotImplementedException();
        }
    }
}