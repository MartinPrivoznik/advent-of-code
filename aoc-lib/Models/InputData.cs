namespace aoc_lib.Models;

public class InputData<T>
{
    public InputData(string dataSet)
    {
        Lines = dataSet.Split("\n")
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => new InputLine<T>(l))
            .ToList();
    }
    
    public List<InputLine<T>> Lines { get; set; }
}