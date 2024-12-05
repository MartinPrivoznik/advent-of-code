using System.Text.RegularExpressions;
using aoc_lib.Base;

namespace aoc._2024;

public class Day3(string sessionKey) : AocBase<string>(2024, 3, sessionKey, true)
{
    public override object SolveTask1()
    {
        var data = Input.RawData;
        const string pattern = @"mul\(([0-9]{1,3}),([0-9]{1,3})\)";
        
        var matches = Regex.Matches(data, pattern);

        var res = matches.Select(m =>
        {
            var value1 = Convert.ToInt32(m.Groups[1].Value);
            var value2 = Convert.ToInt32(m.Groups[2].Value);
            return value1 * value2;
        }).Sum();

        return res;
    }

    public override object SolveTask2()
    {
        var data = Input.RawData;
        
        const string mulPattern = @"mul\(([0-9]{1,3}),([0-9]{1,3})\)";
        const string doPattern = @"do\(\)";
        const string dontPattern = @"don't\(\)";
        
        var mulMatches = Regex.Matches(data, mulPattern);
        var doMatches = Regex.Matches(data, doPattern);
        var dontMatches = Regex.Matches(data, dontPattern);
        
        // load all matches to a single collection sorted by string index
        var allMatches = mulMatches
            .Concat(doMatches)
            .Concat(dontMatches)
            .OrderBy(m => m.Index)
            .ToList();

        var mulEnabled = true;
        var res = 0;

        foreach (var match in allMatches)
        {
            if (Regex.IsMatch(match.Value, doPattern))
                mulEnabled = true;
            else if (Regex.IsMatch(match.Value, dontPattern))
                mulEnabled = false;
            else if (mulEnabled)
            {
                var value1 = Convert.ToInt32(match.Groups[1].Value);
                var value2 = Convert.ToInt32(match.Groups[2].Value);
                res += value1 * value2;
            }
        }

        return res;
    }
}