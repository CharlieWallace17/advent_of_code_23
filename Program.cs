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

            while (char.IsDigit(nextChar) && (indexPointer + 1 < line.Length))
            {
                stringNum += nextChar.ToString();

                indexPointer++;

                nextChar = line[indexPointer + 1 < line.Length ? indexPointer + 1 : indexPointer];
            }

            int fullNum = 0;

            if (int.TryParse(stringNum, out int result)) fullNum = int.Parse(stringNum);

            Console.WriteLine("Checking if num counts: " + fullNum);
            Console.WriteLine("Counts?: " + checkValidNum(fullNum, j, indexPointer, i, lines));

            if (fullNum != 0 && checkValidNum(fullNum, j, indexPointer, i, lines))
            {
                totalSum += fullNum;

                Console.WriteLine(totalSum);
            }

            j = indexPointer + 1;
        }
    }
}

Console.WriteLine(totalSum);


static bool checkValidNum(int num, int startIdx, int endIdx, int currentLineIdx, string[] lines)
{
    string top = "";
    if (currentLineIdx > 0) top = lines[currentLineIdx - 1].Substring((startIdx - 1 < 0 ? startIdx : startIdx - 1), num.ToString().Length + (startIdx - 1 < 0 ? 1 : endIdx + 2 < lines[currentLineIdx].Length ? 2 : 1));

    string left = "";
    if (startIdx > 0) left = lines[currentLineIdx][startIdx - 1].ToString();

    string right = "";
    if ((endIdx + 1) < lines[currentLineIdx].Length) right = lines[currentLineIdx][endIdx + 1].ToString();

    string bottom = "";
    if ((currentLineIdx + 1) < lines.Length) bottom = lines[currentLineIdx + 1].Substring((startIdx - 1 < 0 ? startIdx : startIdx - 1), num.ToString().Length + (startIdx - 1 < 0 ? 1 : endIdx + 2 < lines[currentLineIdx].Length ? 2 : 1));

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




