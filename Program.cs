// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

// convert lines from string[] to List<string>
var lines = System.IO.File.ReadAllLines(@"C:\Users\CharlieW\source\repos\advent_of_code_23\input2.txt");
List<string> originalCodeList = new List<string>();

foreach (var s in lines)
{
    originalCodeList.Add(s);
}


// functions to replace number words with digits
static string findStringNum(string str)
{
    switch (str)
    {
        case "one":
            return "1";
        case "two":
            return "2";
        case "three":
            return "3";
        case "four":
            return "4";
        case "five":
            return "5";
        case "six":
            return "6";
        case "seven":
            return "7";
        case "eight":
            return "8";
        case "nine":
            return "9";
        default: return "";
    }
}

List<string> testNumStrings = new List<string>();
testNumStrings.Add("one");
testNumStrings.Add("two");
testNumStrings.Add("three");
testNumStrings.Add("four");
testNumStrings.Add("five");
testNumStrings.Add("six");
testNumStrings.Add("seven");
testNumStrings.Add("eight");
testNumStrings.Add("nine");

static string replaceStringWithNumString(string codeString, List<string> stringNumList, List<string> newCodeList)
{
    for (int k = 0; k < stringNumList.Count; k++)
    {
        if (codeString.Contains(stringNumList[k]))
        {
            string num = stringNumList[k];
            int index = codeString.IndexOf(num);
            string cleanPath = (index < 0)
                ? codeString
                : codeString.Replace(num, findStringNum(num));
            newCodeList.Add(cleanPath);
        }
    }

    return "";
}

// number names are converted to digits in preparation of final summation
List<string> newCodeList = new List<string>();

for (int i = 0; i < originalCodeList.Count; i++)
{
    replaceStringWithNumString(originalCodeList[i], testNumStrings, newCodeList);
}

// newCodeList is looped through to count the first and last string digits and then sum them
List<long> sumList = new List<long>();
long totalSum = 0;

try
{
    foreach (string inputString in newCodeList)
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
}



