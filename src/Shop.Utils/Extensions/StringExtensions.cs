namespace Shop.Utils;

public static class StringExtensions
{
    public static string? FirstCharToUpper(this string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str[1..];

        return str.ToUpper();

    }
}
