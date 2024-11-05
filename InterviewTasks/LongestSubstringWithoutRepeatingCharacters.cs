namespace InterviewTasks;

/// <summary>
/// 3.
/// Given a string s, find the length of the longest substring without repeating characters.
/// </summary>
public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
            return 0;
        
        var result = 0;
        var currentIndex = 0;
        var charIndexes = new Dictionary<char, int>();
        while (currentIndex <= s.Length - 1)
        {
            var current = s[currentIndex];
            if (charIndexes.TryGetValue(current, out var index))
            {
                currentIndex = index + 1;
                charIndexes.Clear();
                continue;
            }
            
            charIndexes.Add(current, currentIndex);
            currentIndex++;
            if (result < charIndexes.Count)
                result = charIndexes.Count;
        }

        return result;
    }
}