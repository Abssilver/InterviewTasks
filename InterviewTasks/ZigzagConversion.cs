namespace InterviewTasks;

/// <summary>
/// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows.
/// And then read line by line: "PAHNAPLSIIGYIR"
/// P   A   H   N
/// A P L S I I G
/// Y   I   R
/// Write the code that will take a string and make this conversion given a number of rows.
/// </summary>


public class ZigzagConversion
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 0)
            return string.Empty;
        if (numRows == 1)
            return s;

        var charMap = new List<List<char>>();
        for (var i = 0; i < numRows; i++)
            charMap.Add(new List<char>());
        
        var isAscending = true;
        var listIndex = -1;
        for (var i = 0; i < s.Length; i++)
        {
            if (isAscending)
            {
                listIndex++;
                isAscending = listIndex < numRows - 1;
            }
            else
            {
                listIndex--;
                isAscending = listIndex == 0;
            }
            
            charMap[listIndex].Add(s[i]);
        }
        return new string(charMap.SelectMany(x => x).ToArray()); 
    }
}