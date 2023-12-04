using System.Drawing;

var allLines = new List<string>();
var result = 0;
while (Console.ReadLine() is string line)
{
    allLines.Add(line);
}

var linesArray = allLines.ToArray();

var width = linesArray.First().Length;
var height = linesArray.Length;

var map = new char[width, height];

for (var w = 0; w < width; w++)
{
    for (var h = 0; h < height; h++)
    {
        map[w, h] = linesArray[h][w];
    }
}

int currentNumber = 0;
bool hasSymbol = false;

for (var h = 0; h < height; h++)
{
    for (var w = 0; w < width; w++)
    {
        char currentChar = map[w, h];

        if (char.IsDigit(currentChar))
        {
            var value = currentChar - '0';

            currentNumber = (currentNumber * 10) + value;

            foreach (var point in GetPoints())
            {
                var characterW = w + point.X;
                var characterH = h + point.Y;
                
                if (characterW >= width || characterH >= height 
                    || characterW < 0 || characterH < 0)
                {
                    continue;
                }

                var nextCharacter = map[characterW, characterH];

                if(!char.IsDigit(nextCharacter) && nextCharacter != '.')
                {
                    hasSymbol = true;
                }
            }
        }
        else
        {
            if(currentNumber != 0 && hasSymbol)
            {
                result += currentNumber;
            }

            currentNumber = 0;
            hasSymbol = false;
        }
    }

    if (currentNumber != 0 && hasSymbol)
    {
        result += currentNumber;
    }

    currentNumber = 0;
    hasSymbol = false;

}

Console.WriteLine(result);


static Point[] GetPoints() => new Point[]
    {
        new Point(0, 1),
        new Point(1, 0),
        new Point(0, -1),
        new Point(-1, 0),
        new Point(1, 1),
        new Point(-1, 1),
        new Point(1, -1),
        new Point(-1, -1)
    };

