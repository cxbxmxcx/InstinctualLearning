using GeneticSharp.Domain;
using GeneticSharp.Domain.Terminations;

namespace InstinctualLearning
{
    public class InstinctualLearningTermination : ITermination
    {
        private int v;

        public InstinctualLearningTermination(int v)
        {
            this.v = v;
        }

        public bool HasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            throw new System.NotImplementedException();
        }
    }
}