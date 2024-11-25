using System.Text;

namespace InterviewTasks;

/// <summary>
/// 22.
/// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
/// </summary>
public class GenerateParentheses
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var buffer = new StringBuilder();
        buffer.Append('(');
        GenerateData(result, buffer, n, 1, 0);
        return result;
    }

    private void GenerateData(IList<string> result, StringBuilder buffer, int totalParenthesis, int opened, int closed)
    {
        if (buffer.Length == 2 * totalParenthesis)
        {
            result.Add(buffer.ToString());
            return;
        }

        if (opened < totalParenthesis)
        {
            buffer.Append('(');
            GenerateData(result, buffer, totalParenthesis, opened + 1, closed);
            buffer.Remove(buffer.Length - 1, 1);
        }

        if (opened <= closed)
            return;
        
        buffer.Append(')');
        GenerateData(result, buffer, totalParenthesis, opened, closed + 1);
        buffer.Remove(buffer.Length - 1, 1);
    }
}