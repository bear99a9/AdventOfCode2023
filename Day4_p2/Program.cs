var allLines = new List<string>();

while (Console.ReadLine() is string line)
{
    allLines.Add(line);
}

var linesArray = allLines.ToArray();

int[] cardCount = new int[linesArray.Length];


for (int c = 0; c < cardCount.Length; c++)
{
    cardCount[c] = 1;
}

for (int cardId = 0; cardId < linesArray.Length; cardId++)
{
    string? line = linesArray[cardId];

    var gameInformation = line.Split(':');

    var gameNumbers = gameInformation.Last().Split('|');

    var winningNumbers = new List<int>();

    foreach (var winningNumber in gameNumbers.First().Split(" "))
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

    var matchCount = 0; 

    foreach (var winningNo in winningNumbers)
    {
        foreach (var myNumber in myNumbers)
        {
            if (winningNo == myNumber)
            {
                matchCount++;
            }
        }
    }


    for (int n = 0; n < matchCount; n++)
    {
        cardCount[cardId + 1 + n] += cardCount[cardId];
    }
}

Console.WriteLine(cardCount.Sum());
Console.WriteLine();
