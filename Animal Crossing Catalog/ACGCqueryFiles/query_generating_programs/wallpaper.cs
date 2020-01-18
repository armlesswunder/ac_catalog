using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {//change this value to work on a different query (ie: "furniture", "fish", "shirt", ...)
        const string table = "wallpaper";
        const string game = "acgc_";

        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\000ab\\Saved Games\\ACGCqueryFiles\\" + table + "_in.txt");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("C:\\Users\\000ab\\Saved Games\\ACGCqueryFiles\\" + table + "_out.txt", true))
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
                        if (line.Contains(" - ")) {
                            string[] nlArr = line.Split(" - ");
                            foreach (string element in nlArr) {
                                if (element != "" && !element.StartsWith(" ") && !element.StartsWith("\t"))
                                    ls.Add(element);
                            }
                        }
                    }
                    else {
                        string temp = "";
                        str = lhs;
                        if (ls.Count != 0) {
                            str += count++ + ", 0, ";
                            
                            
                            if (ls[0].Contains("["))
                                temp = ls[0].Substring(ls[0].IndexOf("[") + 1, ls[0].IndexOf("]") - 1);
                            else
                            {
                                string s = ls[0].Split(" or ").Last();
                                temp = s;
                            }

                            if (temp.EndsWith('*'))
                                temp = temp.TrimEnd('*');

                            str += "'" + temp + "', ";

                            if (ls[0].Contains('*'))
                                str += "'" + "unorderable', ";
                            else
                                str += "'" + "orderable', ";

                            if (ls[1].Contains("["))
                                str += "'" + ls[1].Substring(ls[1].IndexOf("[") + 1, ls[1].IndexOf("]") - 1) + "') ";
                            else
                                str += "'" + ls[1] + "') ";

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
