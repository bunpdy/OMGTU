#r "Newtonsoft.Json"
using System.IO;

string path = @"C:\Users\bunpdy\hmm\test1.json";

JObject o1 = JObject.Parse(File.ReadAllText(path));

public class BlogPost
{
    public string Cadet { get; set; }
    public string GPA { get; set; }
}

IList<BlogPost> blogPosts = new List<BlogPost>
{
    new BlogPost
    {
        Cadet = "nothing",
        GPA = "nothing",
    }
};

JArray array = new JArray();

// read JSON directly from a file
using (StreamReader file = File.OpenText(path))
using (JsonTextReader reader = new JsonTextReader(file))
{
    List<string> names = new List<string>();

    JObject o2 = (JObject)JToken.ReadFrom(reader);
    IList<string> highest_marks = o2["data"].Where(c => Convert.ToInt32(c["mark"]) == 5).Select(c => c.ToString()).ToList();
    foreach(var element in highest_marks)
    {
        JObject oo = JObject.Parse(element);
        string name = oo["name"].ToString();
        if (names.Contains(name) == false)
        {
            names.Add(name);

            JArray  blogPostsArray = new JArray (
            blogPosts.Select(p => new JObject
            {
                { "Cadet", name },
                { "GPA", oo["mark"]},
            })
            );
            array.Add(blogPostsArray[0]);
        }
    }
}

JObject o = new JObject();
o["Response"] = array;
string json = o.ToString();
Console.WriteLine(json);
