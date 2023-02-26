using System.Security.Cryptography;

namespace bruteforceconsole.Helper;

public static class BruteForceTableArrayGenerator
{
    public static char[,] GenerateTableArray(int maxLength, char[] chars)
    {
        char[,] charTable = new char[maxLength, chars.Length];
        for (int i = 0; i < maxLength; ++i)
        {
            for (int j = 0; j < chars.Length; ++j)
            {
                charTable[i, j] = chars[j];
            }
        }
        return charTable;
    }

    public static void ShuffleTable(char[,] chars)
    {
        int firstArrayLength = chars.GetLength(0);
        int secondArrayLength = chars.GetLength(1);

        for (int i = 0; i < firstArrayLength; ++i)
        {
            for (int j = 0; j < secondArrayLength; ++j)
            {
                char currentChar = chars[i, j];
                int randomArrayPosition = RandomNumberGenerator.GetInt32(secondArrayLength);
                chars[i, j] = chars[i, randomArrayPosition];
                chars[i, randomArrayPosition] = currentChar;
            }
        }
    }
}
