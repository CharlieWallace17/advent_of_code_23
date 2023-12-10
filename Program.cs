// See https://aka.ms/new-console-template for more information

using System.Text;

// convert lines from string[] to List<string>
var lines = System.IO.File.ReadAllLines(@"C:\Users\CharlieW\source\repos\advent_of_code_23\input.txt");
List<string> originalCodeList = new List<string>();

foreach (var s in lines)
{
    originalCodeList.Add(s);
}


// functions to replace number words with digits, leaving letters to account for instances of overlap
static void replaceStringWithNumString(string codeString, List<string> originalList)
{
    int originalIndex = originalList.IndexOf(codeString);

    StringBuilder sb = new StringBuilder(codeString);

    if (codeString.Contains("one"))
    {
        sb.Replace("one", "on1e");
    }

    if (codeString.Contains("two"))
    {
        sb.Replace("two", "tw2o");
    }

    if (codeString.Contains("three"))
    {
        sb.Replace("three", "thre3e");
    }

    if (codeString.Contains("four"))
    {
        sb.Replace("four", "fou4r");
    }

    if (codeString.Contains("five"))
    {
        sb.Replace("five", "fiv5e");
    }

    if (codeString.Contains("six"))
    {
        sb.Replace("six", "si6x");
    }

    if (codeString.Contains("seven"))
    {
        sb.Replace("seven", "seve7n");
    }

    if (codeString.Contains("eight"))
    {
        sb.Replace("eight", "eigh8t");
    }

    if (codeString.Contains("nine"))
    {
        sb.Replace("nine", "nin9e");
    }

    string newString = sb.ToString();

    originalList[originalIndex] = newString;
}

// number strings are converted to digits in preparation of final summation
for (int i = 0; i < originalCodeList.Count; i++)
{
    replaceStringWithNumString(originalCodeList[i], originalCodeList);
}

// newCodeList is looped through to count the first and last string digits, parse them, and then sum them
List<int> sumList = new List<int>();
int totalSum = 0;

try
{
    foreach (string inputString in originalCodeList)
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
            int parsedSumListEntry;

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
}



