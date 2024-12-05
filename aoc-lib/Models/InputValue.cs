using aoc_lib.Utils;

namespace aoc_lib.Models;

public class InputValue<T>(string value)
{
    public T Value { get; set; } = value.CastTo<T>();
}