using System.Collections;
using System.Runtime.Intrinsics.Arm;


var input = File.ReadAllLines("C:\\Users\\Adam\\source\\repos\\consoleApp\\ConsoleApp1\\input.txt");

var sum = input.Aggregate(0, (current, line) =>
{
    var arrNums = new int[9];
    arrNums[0] = line.IndexOf(Digits.one.ToString());
    arrNums[1] = line.IndexOf(Digits.two.ToString());
    arrNums[2] = line.IndexOf(Digits.three.ToString());
    arrNums[3] = line.IndexOf(Digits.four.ToString());
    arrNums[4] = line.IndexOf(Digits.five.ToString());
    arrNums[5] = line.IndexOf(Digits.six.ToString());
    arrNums[6] = line.IndexOf(Digits.seven.ToString());
    arrNums[7] = line.IndexOf(Digits.eight.ToString());
    arrNums[8] = line.IndexOf(Digits.nine.ToString());

    var minWordIndex = arrNums.Select(x => x == -1 ? int.MaxValue : x).Min(x => x);
    var minDigitIndex = line.IndexOfAny(['1', '2', '3', '4', '5', '6', '7', '8', '9']);
    if (minDigitIndex == -1)
        minDigitIndex = int.MaxValue;

    var firstVal = minWordIndex < minDigitIndex ? arrNums.ToList().IndexOf(minWordIndex) + 1 : int.Parse(line[minDigitIndex].ToString());


    arrNums = new int[9];
    arrNums[0] = line.LastIndexOf(Digits.one.ToString());
    arrNums[1] = line.LastIndexOf(Digits.two.ToString());
    arrNums[2] = line.LastIndexOf(Digits.three.ToString());
    arrNums[3] = line.LastIndexOf(Digits.four.ToString());
    arrNums[4] = line.LastIndexOf(Digits.five.ToString());
    arrNums[5] = line.LastIndexOf(Digits.six.ToString());
    arrNums[6] = line.LastIndexOf(Digits.seven.ToString());
    arrNums[7] = line.LastIndexOf(Digits.eight.ToString());
    arrNums[8] = line.LastIndexOf(Digits.nine.ToString());

    var maxWordIndex = arrNums.Max(x => x);
    var maxDigitIndex = line.LastIndexOfAny(['1', '2', '3', '4', '5', '6', '7', '8', '9']);

    var secondVal = maxWordIndex > maxDigitIndex ? arrNums.ToList().IndexOf(maxWordIndex) + 1 : int.Parse(line[maxDigitIndex].ToString());

    var val = int.Parse(firstVal.ToString() + secondVal.ToString());

    return current + val;

});

Console.WriteLine(sum);

enum Digits
{
    one = 1,
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine
};