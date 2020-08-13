namespace Framework.Game
{
    public interface IPuzzle<in TSolution>  where TSolution : IPuzzleSolution
    {
        bool IsSolutionAccepted(TSolution proposedSolution);
    }
}
