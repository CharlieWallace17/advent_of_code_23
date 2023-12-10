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
static void findAndReplaceStringNum(string subStr, string codeString, int index, List<string> originalStringList)
{
    if (subStr == "on") 
        {
        string newString = codeString.Remove(index, 3).Insert(index, "on1e");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
        }
    else if (subStr == "tw")
    {
        string newString = codeString.Remove(index, 3).Insert(index, "tw2o");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "th")
    {
        string newString = codeString.Remove(index, 5).Insert(index, "thre3e");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "fo")
    {
        string newString = codeString.Remove(index, 4).Insert(index, "fou4r");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "fi")
    {
        string newString = codeString.Remove(index, 4).Insert(index, "fiv5e");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "si")
    {
        string newString = codeString.Remove(index, 3).Insert(index, "si6x");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "se")
    {
        string newString = codeString.Remove(index, 5).Insert(index, "seve7n");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "ei")
    {
        string newString = codeString.Remove(index, 5).Insert(index, "eigh8t");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
    }
    else if (subStr == "ni")
    {
        string newString = codeString.Remove(index, 4).Insert(index, "nin9e");

        int listIndex = originalStringList.IndexOf(codeString);

        originalStringList[listIndex] = newString;
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

static void replaceStringWithNumString(string codeString, List<string> stringNumList, List<string> originalList)
{

    int originalIndex = originalList.IndexOf(codeString);

    // replace number word at codeString beginning (if any)
    int startPos = stringNumList.Select(o => codeString.IndexOf(o))
                      .Where(i => i != -1).DefaultIfEmpty(-1).Min();

    if (startPos >= 0)
    {
        string subStartStr = codeString.Substring(startPos, 2);

        findAndReplaceStringNum(subStartStr, codeString, startPos, originalList);
    }

    // replace number word at codeString end (if any), using updated codeString
    string newCodeString = originalList[originalIndex];

    int endPos = stringNumList.Select(o => newCodeString.IndexOf(o))
                      .Where(i => i != -1).DefaultIfEmpty(-1).Max();

    if (endPos >= 0)
    {
        string subEndStr = newCodeString.Substring(endPos, 2);

        findAndReplaceStringNum(subEndStr, newCodeString, endPos, originalList);
    }

}

// number names are converted to digits in preparation of final summation
//originalCodeList.ForEach(x => Console.WriteLine(x));

for (int i = 0; i < originalCodeList.Count; i++)
{
    replaceStringWithNumString(originalCodeList[i], testNumStrings, originalCodeList);
}

// newCodeList is looped through to count the first and last string digits and then sum them
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



