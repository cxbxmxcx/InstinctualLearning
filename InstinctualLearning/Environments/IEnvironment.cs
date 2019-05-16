namespace InstinctualLearning
{
    public interface IEnvironment
    {
        int State { get;  }
        double FinalReward { get; }
        double ExpectedReward { get; }

        double Act(double act);
    }
}