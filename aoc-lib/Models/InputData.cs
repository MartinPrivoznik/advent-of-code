namespace aoc_lib.Models;

public class InputData<T>
{
    public InputData(string dataSet)
    {
        Rows = dataSet.Split("\n")
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => new InputLine<T>(l))
            .ToList();
    }

    public List<InputLine<T>> Rows { get; set; }
    
    public List<T> Column(int index)
    {
        return Rows.Select(l => l.Values[index]).ToList();
    }
}