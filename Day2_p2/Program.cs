using System.Text.RegularExpressions;

var runningTotal = 0;

while (Console.ReadLine() is { } line)
{
    var gameInformation = line.Split(':');
    var rounds = gameInformation.Last().Split(';', StringSplitOptions.TrimEntries);

    int redCount = 0;
    int greenCount = 0;
    int blueCount = 0;
    var roundCount = 0;

    foreach (var round in rounds)
    {
        roundCount++;
        var colourResults = round.Split(',', StringSplitOptions.TrimEntries);
        foreach (var colourResult in colourResults)
        {
            var colorTypeAndCount = colourResult.Split(' ');
            var colourAmount = GetFirstNumberFromString(colorTypeAndCount.First());
            var colour = colorTypeAndCount.Last();

            switch (colour)
            {
                case "red":
                    if(colourAmount > redCount)
                        redCount = colourAmount;
                    break;
                case "green":
                    if (colourAmount > greenCount)
                        greenCount = colourAmount;
                    break;
                case "blue":
                    if (colourAmount > blueCount)
                        blueCount = colourAmount;
                    break;
            }
        }

        if (rounds.Length == roundCount )
        {
            runningTotal += redCount * greenCount * blueCount;
        }
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