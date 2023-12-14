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

        string stringNum = "";

        int indexPointer = j;

        if (char.IsDigit(l))
        {
            stringNum = l.ToString();

            char nextChar = line[indexPointer + 1];

            while (nextChar != '.' && nextChar != '\n')
            {
                stringNum += nextChar.ToString();

                indexPointer++;

                nextChar = line[indexPointer + 1];
            }

            int fullNum = 0;

            if (int.TryParse(stringNum, out int result)) fullNum = int.Parse(stringNum);

            if (checkValidNum(fullNum, j, indexPointer, i, lines))
            {
                totalSum += fullNum;
            }

            j = indexPointer;
        }
    }
}

Console.WriteLine(totalSum);


static bool checkValidNum(int num, int startIdx, int endIdx, int currentLineIdx, string[] lines)
{
    string top = "";
    if (currentLineIdx > 0) top = lines[currentLineIdx - 1].Substring((startIdx - 1 < 0 ? startIdx : startIdx - 1), num.ToString().Length);
    string left = "";
    if (startIdx > 0) left = lines[currentLineIdx][startIdx - 1].ToString();
    string right = "";
    if ((endIdx + 1) < lines[currentLineIdx].Length) right = lines[currentLineIdx][endIdx + 1].ToString();
    string bottom = "";
    if ((currentLineIdx + 1) < lines[currentLineIdx].Length) bottom = lines[currentLineIdx + 1].Substring((startIdx - 1 < 0 ? startIdx : startIdx - 1), num.ToString().Length + 1);

    StringBuilder sb = new StringBuilder();
    string checkStrings = sb.Append(top + left + right + bottom).ToString();

    foreach (char c in checkStrings)
    {
        if (!char.IsDigit(c) && c != '.')
        {
            return true;
        }
    }

    return false;
}




