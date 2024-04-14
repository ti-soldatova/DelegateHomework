using System.Collections;

namespace DelegateHomework;

public static class Number
{
    public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
    {
        (T tvalue, float fvalue) max = default;

        foreach (var c in collection)
        {
            T tvalue = (T)c;
            float fvalue = convertToNumber(tvalue);

            if (fvalue > max.fvalue)
            {
                max = (tvalue, fvalue);
            }
        }

        Console.WriteLine(max.tvalue);

        return max.tvalue;
    }
}
