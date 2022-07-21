using System.Text;
using System.Text.RegularExpressions;

namespace Labs.GithubAction;

public class StringConvert
{
    public string ConvertOrdString(string origin)
    {
        StringBuilder sb = new StringBuilder();

        // Yhe origin data length must be even
        if (origin.Length % 2 != 0)
        {
            throw new NotSupportedException("Data length check failed.");
        }

        // The origin string should only has numeric text
        string searchPatten = "[^0-9]";
        var match = Regex.Match(origin, searchPatten);
        if (match.Success)
        {
            throw new NotSupportedException("Format not supported");
        }

        for (int i = 0; i <= origin.Length - 2; i += 2)
        {
            string s = origin.Substring(i, 2);
            sb.Append((char)(int.Parse(s) + 45));
        }

        return sb.ToString();
    }
}