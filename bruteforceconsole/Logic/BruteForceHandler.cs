using System.Numerics;
using System.Text;

namespace bruteforceconsole.Logic;

public class BruteForceHandler
{
    private char[,] charTable;
    private int[] currentPositions;

    private const int DefaultNullCharacterValue = -1;

    public BruteForceHandler(char[,] charTable)
    {
        this.charTable = charTable;
        currentPositions = new int[charTable.GetLength(0)];
        InitializeCurrentPositions();
    }

    private void InitializeCurrentPositions()
    {
        currentPositions = new int[charTable.GetLength(0)];
        for (int i = 0; i < currentPositions.Length; ++i)
        {
            currentPositions[i] = DefaultNullCharacterValue;
        }
    }

    public string GetNextString()
    {
        IncreaseArrayPositions();
        string nextString = GetString();
        return nextString;
    }

    private string GetString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < charTable.GetLength(0); ++i)
        {
            int currentPositionValue = currentPositions[i];
            switch (currentPositionValue)
            {
                case DefaultNullCharacterValue:
                    continue;
                default:
                    char nextChar = charTable[i, currentPositionValue];
                    builder.Append(nextChar);
                    break;
            }

        }
        return builder.ToString();
    }

    private void IncreaseArrayPositions()
    {
        int maxCharsAtSecondDimension = charTable.GetLength(1);
        for (int i = currentPositions.Length - 1; i >= 0; --i)
        {
            if (currentPositions[i] >= maxCharsAtSecondDimension - 1)
            {
                currentPositions[i] = 0;
            }
            else
            {
                ++currentPositions[i];
                break;
            }
        }
    }

    public BigInteger GetTotalPossibleCombinations()
    {
        return BigInteger.Pow(charTable.GetLength(1) + 1, charTable.GetLength(0));
    }
}
/*

max 3 each
[1, 2, 2]
Wenn letzte Position erhöhbar, erhöhen
Ansonsten die vorherige Position erhöhen und aktuelle Position 0 setzen
*/