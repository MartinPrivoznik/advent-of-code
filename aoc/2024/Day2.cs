using aoc_lib.Base;
using aoc_lib.Utils;

namespace aoc._2024;

public class Day2(string sessionKey) : AocBase<int>(2024, 2, sessionKey)
{
    public override object SolveTask1()
    {
        var validRows = 0;
        
        foreach (var row in Input.Rows)
        {
            var isSorted = row.Values.IsSorted();
            var neighborsAreCloseEnough = row.Values.NeighborsDifferByMaxOf(3);
            
            if (isSorted && neighborsAreCloseEnough)
                validRows++;
        }

        return validRows;
    }

    public override object SolveTask2()
    {
        throw new NotImplementedException();
    }
}