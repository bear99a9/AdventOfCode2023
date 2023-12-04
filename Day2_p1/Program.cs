using System.Text.RegularExpressions;

const int MaxRed = 12;
const int MaxGreen = 13;
const int MaxBlue = 14;

var runningTotal = 0;

while (Console.ReadLine() is { } line)
{
    bool isValidGame = true;

    var gameInformation = line.Split(':');
    var gameId = GetFirstNumberFromString(gameInformation.First());
    var rounds = gameInformation.Last().Split(';', StringSplitOptions.TrimEntries);

    foreach (var round in rounds)
    {
        var colourResults = round.Split(',', StringSplitOptions.TrimEntries);
        foreach (var colourResult in colourResults)
        {
            var colorTypeAndCount = colourResult.Split(' ');
            var colourAmount = GetFirstNumberFromString(colorTypeAndCount.First());
            var colour = colorTypeAndCount.Last();

            switch (colour)
            {
                case "red":
                    if (colourAmount > MaxRed)
                    {
                        isValidGame = false;
                    }
                    break;
                case "green":
                    if (colourAmount > MaxGreen)
                    {
                        isValidGame = false;
                    }
                    break;
                case "blue":
                    if (colourAmount > MaxBlue)
                    {
                        isValidGame = false;
                    }
                    break;
            }
        }

        if (!isValidGame)
        {
            break;
        }
    }

    if (isValidGame)
    {
        runningTotal += gameId;
    }
}

Console.WriteLine(runningTotal);


static int GetFirstNumberFromString(string input)
{
    Match match = MyRegex().Match(input);

    if (match.Success)
    {
        return int.Parse(match.Value);
    }
    else
    {
        throw new Exception("NaN");
    }
}

partial class Program
{
    [GeneratedRegex("\\d+")]
    private static partial Regex MyRegex();
}