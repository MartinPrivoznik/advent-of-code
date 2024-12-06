namespace aoc_lib.Utils;

public static class Extensions
{
    public static T CastTo<T>(this object obj)
    {
        return (T)Convert.ChangeType(obj, typeof(T));
    }
    
    public static bool IsSorted<T>(this List<T> list) where T : IComparable<T>
    {
        return list.IsSortedAscending() || list.IsSortedDescending();
    }
    
    public static bool NeighborsDifferByMaxOf(this List<int> list, int value)
    {
        for (var i = 0; i < list.Count - 1; i++)
        {
            var absDiff = Math.Abs(list[i] - list[i + 1]);
            
            if (absDiff > value || absDiff < 1)
            {
                return false;
            }
        }
        return true;
    }
    
    public static List<List<char>> As2DList(this string input, string lineSeparator = "\n")
    {
        return input.Split(lineSeparator)
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => l.ToCharArray().ToList())
            .ToList();
    }

    private static bool IsSortedAscending<T>(this List<T> list) where T : IComparable<T>
    {
        return list.SequenceEqual(list.OrderBy(x => x));
    }

    private static bool IsSortedDescending<T>(this List<T> list) where T : IComparable<T>
    {
        return list.SequenceEqual(list.OrderByDescending(x => x));
    }
}