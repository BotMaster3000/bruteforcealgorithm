// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using bruteforceconsole.Helper;
using bruteforceconsole.Logic;

Console.WriteLine("Hello, World!");

const int MinPasswordLength = 1;
const int MaxPasswordLength = 5;

const int TotalTests = 50;
string[] randomString = new string[TotalTests];
char[] charTable = BruteForceTables.GetTable(true, true, true);
for (int i = 0; i < TotalTests; ++i)
{
    int passwordLength = RandomNumberGenerator.GetInt32(MinPasswordLength, MaxPasswordLength + 1);
    StringBuilder builder = new StringBuilder();
    for (int j = 0; j < passwordLength; ++j)
    {
        int charIndex = RandomNumberGenerator.GetInt32(-1, charTable.Length);
        if (charIndex > -1)
        {
            builder.Append(charTable[charIndex]);
        }
    }
    randomString[i] = builder.ToString();
}

Task[] tasks = new Task[]{
    Task.Run(RunBruteForceUnshuffled),
    Task.Run(RunBruteForceShuffled)
};

Task.WaitAll(tasks);


void RunBruteForceUnshuffled()
{
    Stopwatch initializationWatch = new Stopwatch();
    Stopwatch bruteForceWatch = new Stopwatch();

    foreach (string randomNumber in randomString)
    {
        initializationWatch.Start();
        char[] numberTable = BruteForceTables.GetTable(true, true, true);
        char[,] tableArray = BruteForceTableArrayGenerator.GenerateTableArray(MaxPasswordLength, numberTable);
        initializationWatch.Stop();

        bruteForceWatch.Start();
        BruteForceHandler handler = new BruteForceHandler(tableArray);
        BigInteger maxCombinations = handler.GetTotalPossibleCombinations();
        bool found = false;
        for (BigInteger i = 0; i < maxCombinations; ++i)
        {
            if (handler.GetNextString() == randomNumber)
            {
                Console.WriteLine("found1 " + randomNumber);
                found = true;
                break;
            }
        }
        bruteForceWatch.Stop();
        if (!found)
        {
            Console.WriteLine("Not1 found" + randomNumber);
        }
    }
    Console.WriteLine("1" + initializationWatch.Elapsed);
    Console.WriteLine("1" + bruteForceWatch.Elapsed);

}

void RunBruteForceShuffled()
{
    Stopwatch initializationWatch = new Stopwatch();
    Stopwatch bruteForceWatch = new Stopwatch();

    foreach (string randomNumber in randomString)
    {
        initializationWatch.Start();
        char[] numberTable = BruteForceTables.GetTable(true, true, true);
        char[,] tableArray = BruteForceTableArrayGenerator.GenerateTableArray(MaxPasswordLength, numberTable);
        BruteForceTableArrayGenerator.ShuffleTable(tableArray);
        initializationWatch.Stop();

        bruteForceWatch.Start();
        BruteForceHandler handler = new BruteForceHandler(tableArray);
        BigInteger maxCombinations = handler.GetTotalPossibleCombinations();
        bool found = false;
        for (BigInteger i = 0; i < maxCombinations; ++i)
        {
            if (handler.GetNextString() == randomNumber)
            {
                Console.WriteLine("found2 " + randomNumber);
                found = true;
                break;
            }
        }
        bruteForceWatch.Stop();
        if (!found)
        {
            Console.WriteLine("Not2 found" + randomNumber);
        }
    }
    Console.WriteLine("2" + initializationWatch.Elapsed);
    Console.WriteLine("2" + bruteForceWatch.Elapsed);
}