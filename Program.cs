// See https://aka.ms/new-console-template for more information

using System.Text;

// convert lines from string[] to List<string>
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\CharlieW\source\repos\advent_of_code_23\input.txt");

for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];

    for (int j = 0; j < line.Length; j++)
    {
        char l = line[j];

        string stringNum = l.ToString();

        int indexPointer = j;

        if (char.IsDigit(l))
        {
            char nextChar = line[indexPointer + 1];

            while (nextChar != '.' && nextChar != '\n')
            {
                stringNum.Concat(nextChar.ToString());

                indexPointer++;
            }

            int fullNum = int.Parse(stringNum);
        }
    }
}





