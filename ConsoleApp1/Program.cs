using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;


var input = File.ReadAllLines("C:\\Users\\Adam\\source\\repos\\consoleApp\\ConsoleApp1\\input.txt");

var dict = new Dictionary<string, string>
{
    {"one", "1" },
    {"two", "2" },
    {"three", "3" },
    {"four", "4" },
    {"five", "5" },
    {"six", "6" },
    {"seven", "7" },
    {"eight", "8" },
    {"nine", "9" },
};


Stopwatch sw = new Stopwatch();

sw.Start();
var sum = input.Aggregate(0, (current, line) =>
{
    var pattern = @"one|two|three|four|five|six|seven|eight|nine|1|2|3|4|5|6|7|8|9";
    var leftMatch = Regex.Match(line, pattern).Value;
    if (dict.TryGetValue(leftMatch, out string? valueL))
        leftMatch = valueL;

    var rightMatch = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
    if (dict.TryGetValue(rightMatch, out string? valueR))
        rightMatch = valueR;

    var num = leftMatch + rightMatch;

    return current + int.Parse(num);
});

sw.Stop();
Console.WriteLine("Elapsed={0}", sw.Elapsed.TotalNanoseconds);

Console.WriteLine(sum);