namespace bruteforceconsole.Helper;

public static class BruteForceTables
{
    public static char[] GetNumberTable()
    {
        return new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    }

    public static char[] GetLowercaseLetterTable()
    {
        return new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n'
        , 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', };
    }

    public static char[] GetUppercaseLetterTable()
    {
        return new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N'
        , 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', };
    }

    public static char[] GetTable(bool includeNumber = false, bool includeLowercase = false, bool includeUppercase = false)
    {
        List<char> chars = new List<char>();
        if (includeNumber)
        {
            chars.AddRange(GetNumberTable());
        }
        if (includeLowercase)
        {
            chars.AddRange(GetLowercaseLetterTable());
        }
        if (includeUppercase)
        {
            chars.AddRange(GetUppercaseLetterTable());
        }
        return chars.ToArray();
    }
}
