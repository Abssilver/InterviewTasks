
namespace InterviewTasks;

/// <summary>
/// 8.
/// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.
/// The algorithm for myAtoi(string s) is as follows:
/// Whitespace: Ignore any leading whitespace (" ").
/// Signedness: Determine the sign by checking if the next character is '-' or '+',
/// assuming positivity if neither present.
/// Conversion: Read the integer by skipping leading zeros until a non-digit character is
/// encountered or the end of the string is reached. If no digits were read, then the result is 0.
/// Rounding: If the integer is out of the 32-bit signed integer range [-2^31, 2^31 - 1],
/// then round the integer to remain in the range. Specifically,
/// integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1.
/// Return the integer as the final result.
/// </summary>
public class StringToInteger
{
    public int MyAtoi(string s)
    {
        var result = 0;
        var wasNumber = false;
        var hasSign = false;
        var isNegative = false;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 43)
            {
                if (hasSign || wasNumber)
                    break;
                hasSign = true;
                isNegative = false;
                continue;
            }

            if (s[i] == 45)
            {
                if (hasSign || wasNumber)
                    break;
                hasSign = true;
                isNegative = true;
                continue;
            }

            if (s[i] >= 48 && s[i] < 58)
            {
                wasNumber = true;
                int remainder;
                if (isNegative)
                {
                    remainder = 48 - s[i];
                    var stepToLimit = int.MinValue / 10;
                    if (result < stepToLimit)
                        return int.MinValue;
                    if (result == stepToLimit && remainder < int.MinValue % 10)
                        return int.MinValue;
                    
                }
                else
                {
                    remainder = s[i] - 48;
                    var stepToLimit = int.MaxValue / 10;
                    if (result > stepToLimit)
                        return int.MaxValue;
                    if (result == stepToLimit && remainder > int.MaxValue % 10)
                        return int.MaxValue;
                }
                
                result = result * 10 + remainder;
                continue;
            }

            if (hasSign || wasNumber || s[i] != 32)
                break;
        }

        return result;
    }
}