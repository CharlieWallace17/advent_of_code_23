// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.IO;
using System.Linq;



var lines = System.IO.File.ReadAllLines(@"C:\Users\CharlieW\source\repos\advent_of_code_23\input.txt");

List<string> LogList = new List<string>();

foreach (var s in lines)
{
    LogList.Add(s);
}

List<long> sumList = new List<long>();
long totalSum = 0;

try
{
    foreach (string inputString in LogList)
    {

        {
            List<char> lineNumsList = new List<char>();

            for (int j = 0; j < inputString.Length; j++)
            {
                char c = inputString[j];

                if (char.IsDigit(c))
                {

                    lineNumsList.Add(c);
                }
            }

            string sumListEntry;
            long parsedSumListEntry;

            if (lineNumsList.Count == 1 && lineNumsList[0] != '0')
            {

                sumListEntry = string.Concat(lineNumsList[0], lineNumsList[0]);

                parsedSumListEntry = int.Parse(sumListEntry);

                sumList.Add(parsedSumListEntry);

            }
            else if (lineNumsList.Count >= 2)
            {
                sumListEntry = string.Concat(lineNumsList[0], lineNumsList[lineNumsList.Count - 1]);

                parsedSumListEntry = int.Parse(sumListEntry);

                sumList.Add(parsedSumListEntry);
            }
        }

    }

}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    sumList.ForEach(x => totalSum += x);
    Console.WriteLine(totalSum.ToString());
    Console.WriteLine("Executing finally block.");
}


