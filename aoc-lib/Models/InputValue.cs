using aoc_lib.Utils;

namespace aoc_lib.Models;

public class InputValue<T>(string value) : IComparable
{
    public T Value { get; set; } = value.CastTo<T>();
    public int CompareTo(object? obj)
    {
        if (obj is InputValue<T> other)
            return Comparer<T>.Default.Compare(Value, other.Value);
        
        return -1;
    }
}