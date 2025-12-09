List<string> allowedSigns = ["rock", "paper", "scissors", "lizard","spock"];
Dictionary<string, List<string>> WiningMap = new();
WiningMap["rock"]= ["scissors", "lizard"];
WiningMap["paper"]=["rock", "spock"];
WiningMap["scissors"]=["paper", "lizard"];
WiningMap["lizard"]=["paper","spock"];
WiningMap["spock"]=["rock", "scissors"];

string GetCorrectSign(string playerName)
{
    Console.WriteLine($"{playerName}, choose your sign ({string.Join('/', allowedSigns)})");
    string sign = Console.ReadLine()!;

   
    while (!allowedSigns.Contains(sign, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine($"{playerName}, choose correct sign ({string.Join('/', allowedSigns)})");
        sign = Console.ReadLine()!;
    }
    return sign;
}
string GetCorrectRandomSign(string playerName)
{
        int signIndex = Random.Shared.Next(allowedSigns.Count);
        string sign = allowedSigns[signIndex];
        Console.WriteLine($"{playerName} selected {sign}");
        return sign;
}


const StringComparison stringComparison = StringComparison.OrdinalIgnoreCase;
int firstPlayerPoints = 0;
int secondPlayerPoints = 0;
while (true)
{
    Console.WriteLine("Let's play Rock-Paper-Scissors-Lizard-Spock!");


    string firstSign = GetCorrectSign("Player 1"); // P1
    string secondSign = GetCorrectSign("Player 2"); // P2
    List<string> signsLosingwithfirstSigns = WiningMap[firstSign];


    if (firstSign.Equals(secondSign, stringComparison))
    {
        Console.WriteLine("It's a draw!");
    }
    else if (signsLosingwithfirstSigns.Contains(secondSign, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine("First player won!");
        //firstPlayerPoints = firstPlayerPoints + 1;
        firstPlayerPoints += 1;
    }
    else
    {
        Console.WriteLine("Second player won!");
        //secondPlayerPoints = secondPlayerPoints + 1;
        secondPlayerPoints += 1;
    }
    Console.WriteLine($" First Player: {firstPlayerPoints}");
    Console.WriteLine($"Second player: {secondPlayerPoints}");
    if (!(firstPlayerPoints >= 3 || secondPlayerPoints >= 3))
    {
        break;
    }
}