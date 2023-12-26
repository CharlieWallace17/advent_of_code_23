// See https://aka.ms/new-console-template for more information

using System.Text;

string[] lines = System.IO.File.ReadAllLines(@"C:\Users\CharlieW\source\repos\advent_of_code_23\input2.txt");

int totalSum = 0;

for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];

    for (int j = 0; j < line.Length; j++)
    {
        char l = line[j];

        if (l == '*')
        {
            //build string out of star border
            string top = findTop(lines, i, j);

            string bottom = findBottom(lines, i, j);

            string left = findLeft(lines, i, j);

            string right = findRight(lines, i, j);

            StringBuilder sb = new StringBuilder();

            string allSides = sb.Append(top + "." + bottom + "." + left + "." + right).ToString();

            string currentStringNum = "";

            List<int> numList = new List<int>();

            int numCounter = 0;

            //iterate through string and create list of numbers
            for (int k = 0; k < allSides.Length; k++)
            {
                if (char.IsDigit(allSides[k]))
                {
                    currentStringNum += allSides[k];
                }

                if ((!char.IsDigit(allSides[k]) && currentStringNum.Length > 0) || (k + 1 == allSides.Length && currentStringNum.Length > 0))
                {
                    int currentNum = int.Parse(currentStringNum);

                    numList.Add(currentNum);

                    numCounter++;

                    currentStringNum = "";
                }
            }

            //check number length and add to totalSum if applicable
            if (numList.Count == 2)
            {

                int ratioNum = numList[0] * numList[1];

                totalSum += ratioNum;
            }

            numList.Clear();
        }
    }
}

Console.WriteLine(totalSum);

static string findTop(string[] lines, int currentLineIndex, int currentCharIndex)
{
    if (currentLineIndex == 0) return "";

    string topLine = lines[currentLineIndex - 1];

    int startingPos = currentCharIndex - 1 > 0 ? currentCharIndex - 1 : currentCharIndex;
    if (char.IsDigit(topLine[startingPos - 1]) && startingPos - 1 >= 0)
    {
        startingPos--;
    }

    int endingPos = currentCharIndex + 1 < topLine.Length ? currentCharIndex + 1 : currentCharIndex;
    if (char.IsDigit(topLine[startingPos + 1]) && startingPos + 1 < topLine.Length)
    {
        startingPos++;
    }

    return topLine.Substring(startingPos, endingPos - startingPos) ?? "";
}

static string findBottom(string[] lines, int currentLineIndex, int currentCharIndex)
{
    if (currentLineIndex + 1 >= lines.Length) return "";

    string bottomLine = lines[currentLineIndex + 1];

    int startingPos = currentCharIndex - 1 > 0 ? currentCharIndex - 1 : currentCharIndex;
    if (char.IsDigit(bottomLine[startingPos - 1]) && startingPos - 1 >= 0)
    {
        startingPos--;
    }

    int endingPos = currentCharIndex + 1 < bottomLine.Length ? currentCharIndex + 1 : currentCharIndex;
    if (char.IsDigit(bottomLine[startingPos + 1]) && startingPos + 1 < bottomLine.Length)
    {
        startingPos++;
    }

    return bottomLine.Substring(startingPos, endingPos - startingPos) ?? "";
}

static string findLeft(string[] lines, int currentLineIndex, int currentCharIndex)
{
    if (currentCharIndex - 1 < 0) return "";

    string leftLine = lines[currentLineIndex];

    int startingPos = currentCharIndex - 1 > 0 ? currentCharIndex - 1 : currentCharIndex;
    if (char.IsDigit(leftLine[startingPos - 1]) && startingPos - 1 >= 0)
    {
        startingPos--;
    }

    int endingPos = currentCharIndex;

    return leftLine.Substring(startingPos, endingPos - startingPos) ?? "";
}

static string findRight(string[] lines, int currentLineIndex, int currentCharIndex)
{
    if (currentCharIndex + 1 >= lines.Length) return "";

    string rightLine = lines[currentLineIndex];

    int startingPos = currentCharIndex;

    int endingPos = currentCharIndex + 1 < rightLine.Length ? currentCharIndex + 1 : currentCharIndex;
    if (char.IsDigit(rightLine[startingPos + 1]) && startingPos + 1 < rightLine.Length)
    {
        endingPos++;
    }

    return rightLine.Substring(startingPos, endingPos - startingPos) ?? "";
}


