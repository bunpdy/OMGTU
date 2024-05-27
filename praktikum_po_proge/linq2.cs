#r "Newtonsoft.Json"
using System.IO;

string path = @"C:\Users\bunpdy\hmm\test2.json";

float sum1 = 0;
float sum2 = 0;
using (StreamReader file = File.OpenText(path))
using (JsonTextReader reader = new JsonTextReader(file))
{

    JObject o2 = (JObject)JToken.ReadFrom(reader);
    IList<int> programming = o2["data"].Where(c => c["discipline"].ToString() == "Programming").Select(b => Convert.ToInt32(b["mark"])).ToList();
    IList<int> algebra = o2["data"].Where(c => c["discipline"].ToString() == "Algebra").Select(b => Convert.ToInt32(b["mark"])).ToList();
    foreach(int element in algebra)
    {
        sum1 += element;
    }
    foreach(int element in programming)
    {
        sum2 += element;
    }
    sum1 = sum1 / algebra.Count();
    sum2 = sum2 / programming.Count();

}

JObject oz1 = new JObject
{
    { "Algebra", sum1 },
};

JObject oz2 = new JObject
{
    { "Programming", sum2 },
};
JArray array = new JArray();
array.Add(oz1);
array.Add(oz2);
JObject o = new JObject();
o["Response"] = array;
string json = o.ToString();
Console.WriteLine(json);
