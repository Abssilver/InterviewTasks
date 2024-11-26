
namespace InterviewTasks;

/// <summary>
/// 29.
/// Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
/// The integer division should truncate toward zero, which means losing its fractional part.
/// For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.
/// Return the quotient after dividing dividend by divisor.
/// Note: Assume we are dealing with an environment that could only store integers within
/// the 32-bit signed integer range: [−2^31, 2^31 − 1].
/// For this problem, if the quotient is strictly greater than 2^31 - 1, then return 2^31 - 1,
/// and if the quotient is strictly less than -2^31, then return -2^31.
/// </summary>
public class DivideTwoIntegers
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        if (divisor == 1)
            return dividend;

        var isMinus = (dividend > 0)^(divisor > 0);
        var result = 0;
        var absDividend = Math.Abs((long)dividend);
        var absDivisor = Math.Abs((long)divisor);
        while (absDividend >= absDivisor) {
            var shift = 0;
            while (absDividend >= (absDivisor << shift)) {
                shift++;
            }
            result += (1 << (shift - 1));
            absDividend -= absDivisor << (shift - 1);
        }
        return isMinus 
            ? -result
            : result;
    }
}