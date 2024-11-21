using System.Text;

namespace InterviewTasks;

/// <summary>
/// 17.
/// Given a string containing digits from 2-9 inclusive,
/// return all possible letter combinations that the number could represent. Return the answer in any order.
/// </summary>
public class LetterCombinationsOfAPhoneNumber
{
    private readonly Dictionary<char, string> _phoneMap = new ()
    {
        { '2', "abc" },
        { '3', "def" },
        { '4', "ghi" },
        { '5', "jkl" },
        { '6', "mno" },
        { '7', "pqrs" },
        { '8', "tuv" },
        { '9', "wxyz" }
    };

    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (digits.Length == 0)
            return result;

        var data = new StringBuilder();
        FillStringData(result, digits, data, 0);
        return result;
    }

    private void FillStringData(List<string> result, string digits, StringBuilder toAppend, int currentIndex)
    {
        if (currentIndex == digits.Length)
        {
            result.Add(toAppend.ToString());
            return;
        }

        var currentLetters = _phoneMap[digits[currentIndex]];
        for (var i = 0; i < currentLetters.Length; i++)
        {
            toAppend.Append(currentLetters[i]);
            FillStringData(result, digits, toAppend, currentIndex + 1);
            toAppend.Remove(toAppend.Length - 1, 1);
        }
    }
}