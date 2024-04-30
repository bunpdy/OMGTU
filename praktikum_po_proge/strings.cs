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

string pattern = @"^([A-z-.0-9]+)[^..]@([A-z-.0-9]+)[^..]\.[A-z-.0-9][^..]{1,}";

Regex rg = new Regex(pattern);  
  
string mail = "PeTrov.19_72.wo-rk@gmail.com.ua";  
MatchCollection matchedTimes = rg.Matches(mail);  
 
foreach (Match match in Regex.Matches(mail, pattern))
{
    if (match.Value == mail)
    {
        Console.WriteLine("True\n");
        Console.WriteLine(mail);
    }
    else
    {
        Console.WriteLine("False");
        break;
    }
}
