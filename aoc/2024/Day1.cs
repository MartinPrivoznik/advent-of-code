using aoc_lib.Base;

namespace aoc._2024;

public class Day1(string sessionKey) : AocBase<int>(2024, 1, sessionKey)
{
    public override object SolveTask1()
    {
        var col1 = Input.Column(0);
        var col2 = Input.Column(1);
        
        col1.Sort();
        col2.Sort();
        
        var distanceSum = col1.Zip(col2, (val1, val2) => Math.Abs(val1.Value - val2.Value)).Sum();
        
        return distanceSum;
    }

    public override object SolveTask2()
    {
        var col1 = Input.Column(0);
        var col2 = Input.Column(1);

        var similarity = col1.Select(c => c.Value * col2.Count(c2 => c2.Value == c.Value)).Sum();
        return similarity;
    }
}