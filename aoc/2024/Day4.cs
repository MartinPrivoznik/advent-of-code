using aoc_lib.Base;
using aoc_lib.Models;
using aoc_lib.Utils;

namespace aoc._2024;

public class Day4(string sessionKey) : AocBase<string>(2024, 4, sessionKey)
{
    private static bool IsInBounds(int x, int y, int width, int height)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
    
    public override object SolveTask1()
    {
      const string finalWord = "XMAS";

      (int, int)[] directions =
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
                if (ch != finalWord[0]) continue;

                // Validate all directions
                foreach (var (dx, dy) in directions)
                {
                    var wordMatches = false;
                    
                    // Check whole word
                    for (var k = 1; k < finalWord.Length; k++)
                    {
                        var x = j + k * dx;
                        var y = i + k * dy;

                        if (!IsInBounds(x, y, width, height))
                            break;

                        if (matrix[y][x] != finalWord[k])
                            break;

                        if (k == finalWord.Length - 1)
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
        var matrix = Input.RawData.As2DList();

        var xmasCount = 0;

        // skip first and last row
        for (var i = 1; i < matrix.Count - 1; i++)
        {
            var row = matrix[i];

            // skip first and last column
            for (var j = 1; j < row.Count - 1; j++)
            {
                if (matrix[i][j] != 'A') continue;
                
                var word1 = new string(new[] {matrix[i - 1][j - 1], matrix[i][j], matrix[i + 1][j + 1]});
                var word2 = new string(new[] {matrix[i - 1][j + 1], matrix[i][j], matrix[i + 1][j - 1]});
                
                if (word1 is "MAS" or "SAM" &&
                    word2 is "MAS" or "SAM")
                {
                    xmasCount++;
                }
            }
        }

        return xmasCount;
    }
}