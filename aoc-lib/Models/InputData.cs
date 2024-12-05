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

    private List<InputLine<T>> Lines { get; set; }

    public List<InputValue<T>> Row(int index)
    {
        return Lines[index].Values;
    }
    public List<InputValue<T>> Column(int index)
    {
        return Lines.Select(l => l.Values[index]).ToList();
    }
}