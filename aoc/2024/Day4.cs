using aoc_lib.Base;
using aoc_lib.Models;
using aoc_lib.Utils;

namespace aoc._2024;

public class Day4(string sessionKey) : AocBase<string>(2024, 4, sessionKey)
{
    private const string FINAL_WORD = "XMAS";

    private readonly (int, int)[] _directions =
    [
        (1, 0),
        (-1, 0),
        (0, 1), 
        (0, -1), 
        (1, 1),
        (1, -1),
        (-1, 1),
        (-1, -1)
    ];
    
    private bool IsInBounds(int x, int y, int width, int height)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
    
    public override object SolveTask1()
    {
        var matrix = Input.RawData.As2DList();
        
        var width = matrix[0].Count;
        var height = matrix.Count;

        var wordCount = 0;
        
        for (var i = 0; i < matrix.Count; i++)
        {
            var row = matrix[i];
            
            for (var j = 0; j < row.Count; j++)
            {
                var ch = row[j];
                
                // Skip if the first letter of the word does not match
                if (ch != FINAL_WORD[0]) continue;

                // Validate all directions
                foreach (var (dx, dy) in _directions)
                {
                    var wordMatches = false;
                    
                    for (var k = 1; k < FINAL_WORD.Length; k++)
                    {
                        var x = j + k * dx;
                        var y = i + k * dy;

                        if (!IsInBounds(x, y, width, height))
                            break;

                        if (matrix[y][x] != FINAL_WORD[k])
                            break;

                        if (k == FINAL_WORD.Length - 1)
                            wordMatches = true;
                    }
                    
                    if (wordMatches)
                        wordCount++;
                }
            }
        }

        return wordCount;
    }

    public override object SolveTask2()
    {
        throw new NotImplementedException();
    }
}