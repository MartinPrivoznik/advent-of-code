namespace aoc_lib.Models;

public class InputLine<T>
{
    public InputLine(string line)
    {
        Values = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)
            .Select(v => new InputValue<T>(v))
            .ToList();
    }
    
    public List<InputValue<T>> Values { get; set; }
}