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

Console.WriteLine($"Time spent: {sw.Elapsed}");
Console.WriteLine($"result line: {sb}");
