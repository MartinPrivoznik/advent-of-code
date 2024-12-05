namespace aoc_lib.Utils;

public static class Extensions
{
    public static T CastTo<T>(this object obj)
    {
        return (T)Convert.ChangeType(obj, typeof(T));
    }
}