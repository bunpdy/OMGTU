string people1 = "Bob";
string people2 = "Tom";
string people3 = "Eva";
string word  = " friendship bracelet ";

Console.WriteLine(people1.Length);

Console.WriteLine(people1.ToUpper());

Console.WriteLine(people1.ToLower());

Console.WriteLine("supercalifragilisticexpialidocious".Length);

int result = word.Length - word.Trim().TrimStart().TrimEnd().Length;
Console.WriteLine(result); // center space is not cut 


//////////////////////////

using System.Diagnostics;
var sw = new Stopwatch();
var sw2 = new Stopwatch();

static string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
static Random r = new Random();
static char GetRandomChar()
{
    var index = r.Next(symbols.Length);
    return symbols[index];
}

string value = "abcdefghij";
StringBuilder sb = new StringBuilder(value);

sw.Start();

for (int i = 0; i < 1000000; i++)
{
    sb[i % 10] = GetRandomChar();
}

sw.Stop();

sw2.Start();

for (int i = 0; i < 6; i++)
{
    int ind = i % 10;
    value = value.Remove(ind, 1).Insert(ind, GetRandomChar().ToString());
}
sw2.Stop();

Console.WriteLine("StringBuilder:");
Console.WriteLine($"Time spent: {sw.Elapsed}");
Console.WriteLine($"result line: {sb} \n");

Console.WriteLine("Direct string conversion:");
Console.WriteLine($"Time spent: {sw2.Elapsed}");
Console.WriteLine($"result line: {value}");

////////////////////////////////////////

using System.Text.RegularExpressions;

string pattern = @"(([01][0-9]|[2][0-3])\:([0-5][0-9]))";

Regex rg = new Regex(pattern);  
  
string time = "dwad00:00dwad23:14";  
MatchCollection matchedTimes = rg.Matches(time);  
 
foreach (Match match in Regex.Matches(time, pattern, RegexOptions.IgnoreCase))
      Console.WriteLine("{0} at position {2}",
                           match.Value, match.Groups[1].Value, match.Index);

