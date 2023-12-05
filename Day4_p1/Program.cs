var runningTotal = 0;

while (Console.ReadLine() is { } line)
{
    var gameInformation = line.Split(": ");

    var gameNumbers = gameInformation.Last().Split(" | ");

    var winningNumbers = new List<int>();

    foreach ( var winningNumber in gameNumbers.First().Split(" "))
    {
        if (!string.IsNullOrEmpty(winningNumber))
        {
            winningNumbers.Add(int.Parse(winningNumber));
        }
    }
    
    var myNumbers = new List<int>();

    foreach (var myNumber in gameNumbers.Last().Split(" "))
    {
        if (!string.IsNullOrEmpty(myNumber))
        {
            myNumbers.Add(int.Parse(myNumber));
        }
    }

    var currentGameScore = 0;

    foreach(var winningNo in winningNumbers)
    {
        foreach (var myNumber in myNumbers)
        {
            if (winningNo == myNumber)
            {
                if (currentGameScore == 0)
                {
                    currentGameScore++;
                }
                else
                {
                    currentGameScore *= 2;
                }
            }
        }
    }

    runningTotal += currentGameScore;
}

Console.WriteLine(runningTotal);


