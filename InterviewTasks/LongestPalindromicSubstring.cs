namespace InterviewTasks;

/// <summary>
/// 5.
/// Given a string s, return the longest palindromic substring in s.
/// </summary>
public class LongestPalindromicSubstring
{
    public string LongestPalindrome(string s)
    {
        if (s.Length < 2)
            return s;

        var startIndex = 0;
        var size = 0;

        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 0; j <= 1; j++)
            {
                var left = i;
                var right = i + j;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    var currentSize = right - left + 1;
                    if (currentSize > size)
                    {
                        startIndex = left;
                        size = currentSize;
                    }
                    left--;
                    right++;
                }
            }
        }

        return s.Substring(startIndex, size);
    }
}