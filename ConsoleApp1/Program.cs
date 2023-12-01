using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;


var input = File.ReadAllLines("C:\\Users\\Adam\\source\\repos\\consoleApp\\ConsoleApp1\\input.txt");

var dict = new Dictionary<string, string> { { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" }, { "six", "6" }, { "seven", "7" }, { "eight", "8" }, { "nine", "9" }, };

var sum = input.Aggregate(0, (current, line) =>
{
    var pattern = string.Join("|", dict.Keys) + "|1|2|3|4|5|6|7|8|9";
    var leftMatch = GetDigit(Regex.Match(line, pattern).Value);
    var rightMatch = GetDigit(Regex.Match(line, pattern, RegexOptions.RightToLeft).Value);

    return current + int.Parse(leftMatch + rightMatch);
});

string GetDigit(string input) => dict.TryGetValue(input, out string? value) ? value : input;


Console.WriteLine(sum);