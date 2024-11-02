namespace InterviewTasks;

/// <summary>
/// 69.
/// Given a non-negative integer x, return the square root of x rounded down to the nearest integer.
/// The returned integer should be non-negative as well.
/// You must not use any built-in exponent function or operator.
/// </summary>
public class Sqrt
{
    public int MySqrt(int x)
    {
        var current = x;
        var stack = new Stack<int>();
        while (current > 0)
        {
            var remain = current / 100;
            var value = current - remain * 100;
            stack.Push(value);
            current /= 100;
        }

        current = 0;
        var resultList = new List<int>();
        while (stack.Count != 0)
        {
            current += stack.Pop();
            var divider = 1;
            var additive = GetAdditive(resultList);
            while ((additive + divider) * divider <= current)
                divider++;
            resultList.Add(--divider);
            current -= ((additive + divider) * divider);
            if (current > 0)
                current *= 100;
        }

        var result = 0;
        var multiplier = 1;
        for (var i = resultList.Count - 1; i >= 0; i--)
        {
            result += resultList[i] * multiplier;
            multiplier *= 10;
        }
        return result;
    }

    private int GetAdditive(List<int> resultList)
    {
        if (resultList.Count == 0)
            return 0;

        var result = 0;
        for (var i = 0; i < resultList.Count; i++)
        {
            result *= 10;
            result += resultList[i];
        }

        return result * 20;
    }
}