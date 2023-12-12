// See https://aka.ms/new-console-template for more information

using System.Text;

// convert lines from string[] to List<string>
var games = System.IO.File.ReadAllLines(@"C:\Users\CharlieW\source\repos\advent_of_code_23\input.txt");

List<string> originalGameList = new List<string>();

List<int[]> newGameList = new List<int[]>();

foreach (var g in games)
{
    originalGameList.Add(g);
}

for (int i = 0; i < originalGameList.Count; i++)
{
    string currentGame = originalGameList[i];

    // extract game # in int format
    string gameNumString = currentGame.Split(':')[0];

    int gameNum = int.Parse(gameNumString.Split(" ")[1]);

    // format game outcomes for summation
    int isPossible = 1;

    string gameOutcomeString = currentGame.Split(":")[1].Trim();

    string[] subGamesArray = gameOutcomeString.Split(";");

    foreach (var miniGame in subGamesArray)
    {
        string[] colorTallys = miniGame.Split(",");

        List<string> trimmedList = new List<string>();

        // miniGames are now trimmed and formatted equivalently 
        foreach (var ct in colorTallys)
        {
            string trimmedTally = ct.Trim();
            trimmedList.Add(trimmedTally);
        }

        foreach (var tally in trimmedList)
        {
            int tallyNum = int.Parse(tally.Split(" ")[0]);

            string tallyColor = tally.Split(" ")[1];

            if ((tallyColor == "red" && tallyNum > 12) || (tallyColor == "green" && tallyNum > 13) || (tallyColor == "blue" && tallyNum > 14))
            {
                isPossible = 0;
            }
        }
    }

    // create array with values and push into new list
    int[] gameStats = { gameNum, isPossible };

    newGameList.Add(gameStats);
}

// iterate through formatted data to sum game ID values
int totalSum = 0;
for (int i = 0; i < newGameList.Count; i++)
{
    if (newGameList[i][1] == 1)
    {
        totalSum += newGameList[i][0];
    }
}

Console.WriteLine(totalSum);


