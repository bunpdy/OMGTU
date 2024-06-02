using System;
using System.Reflection;
using System.Reflection.Emit;


void DataOutput(string dll)
{
    Assembly asm = Assembly.LoadFrom(dll);
    Type[] types = asm.GetTypes();

    for (int i = 0; i < types.Length; i++)
    {
        MethodInfo[] Methods = types[i].GetMethods(); // Атрибут BindingFlags.Public дает мало методов
        Console.WriteLine(types[i]);
        string res = "";
        Console.WriteLine("\nmethods:");
        foreach(var method in Methods)
        {
            Console.Write(method.Name + "\n");
            ParameterInfo[] Params = method.GetParameters();
            foreach (ParameterInfo Param in Params)
            {
                string rtrn_type = ("ReturnType=" + method.ReturnType.ToString());
                string name = ("Param=" + Param.Name.ToString());
                string type = ("Type=" + Param.ParameterType.ToString());
                res = string.Join("\n ", new string[] {rtrn_type, name, type});
                Console.WriteLine("{"+ res + "}");
            }
        }
        Console.WriteLine("\n");
    }
}
