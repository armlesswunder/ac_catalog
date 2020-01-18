using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class query_gen
    {
        // change this value to work on a different query (i.e.: "furniture", "fish", "shirt", ...)
        const string table = "fossil";
        const string game = "accf_";

        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\000ab\\Saved Games\\ACCFqueryFiles\\" + table + "_in.txt");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("C:\\Users\\000ab\\Saved Games\\ACCFqueryFiles\\" + table + "_out.txt", true))
            {
                string lhs = "insert into " + game + table + " values(";
                string str;
                int count = 1;
                string[] arr;
                List<string> ls = new List<string>();
                foreach (string line in lines)
                {

                    // ([name] ...) - ([from] ... || grp ...) - size - prices - opt(color) - description
                    if (line == "" || line.StartsWith(' ') || line.StartsWith('-') || line.EndsWith(':') || line.StartsWith('\t') || line.StartsWith('\n'))
                    {
                        if (line.Contains(" - "))
                        {
                            string[] nlArr = line.Split(" - ");
                            foreach (string element in nlArr)
                            {
                                if (element != "" && !element.StartsWith(" ") && !element.StartsWith("\t"))
                                    ls.Add(element);
                            }
                        }
                    }
                    else
                    {
                        string temp = "";
                        str = lhs;
                        if (ls.Count != 0)
                        {
                            str += count++ + ", 0, ";

                            string[] r = ls[3].Split("/");
                            string color1 = r[0];
                            string color2 = r[1];
                            

                            str += "'" + ls[0] + "', '" + color1 + "', '" + color2 + "')";

                            
                            Console.WriteLine(str);
                            file.WriteLine(str);

                        }
                        arr = line.Split(" - ");
                        ls = arr.OfType<string>().ToList();
                    }
                }
            }
        }
    }
}
