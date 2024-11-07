namespace InterviewTasks;

/// <summary>
/// Given a signed 32-bit integer x, return x with its digits reversed.
/// If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
/// Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
/// </summary>
public class ReverseInteger
{
    public int Reverse(int x)
    {
        var isMinus = x < 0;
        var result = 0;
        while (x != 0)
        {
            var remainder = x % 10;
            x /= 10;
            if (isMinus)
            {
                var stepToLimit = int.MinValue / 10;
                if (result < stepToLimit)
                    return 0;
                if (result == stepToLimit && remainder < int.MinValue % 10)
                    return 0;
            }
            else
            {
                var stepToLimit = int.MaxValue / 10;
                if (result > stepToLimit)
                    return 0;
                if (result == stepToLimit && remainder > int.MaxValue % 10)
                    return 0;
            }
            result = result * 10 + remainder;
        }

        return result;
    }
}