namespace InterviewTasks;

/// <summary>
/// 70.
/// You are climbing a staircase. It takes n steps to reach the top.
/// Each time you can either climb 1 or 2 steps.
/// In how many distinct ways can you climb to the top?
/// </summary>
public class ClimbingStairs
{
    private readonly Dictionary<int, int> _results = new()
    {
        {0, 0},
        {1, 1},
        {2, 2},
    };
    public int ClimbStairs(int n)
    {
        if (_results.TryGetValue(n, out var cached))
            return cached;

        var resultOfMinusOne = ClimbStairs(n - 1);
        var resultOfMinusTwo = ClimbStairs(n - 2);

        _results[n] = resultOfMinusOne + resultOfMinusTwo;
        return _results[n];
    }
}