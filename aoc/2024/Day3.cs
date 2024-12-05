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
        throw new NotImplementedException();
    }
}