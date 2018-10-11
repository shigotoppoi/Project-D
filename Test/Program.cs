using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //string s = @"\(s\)\(s\) \[n \(s\)\]s";
            string s = @"\[s\] n \[s\]s";
            string g = "g";
            g.Substring(0, 3);

            //ss(s);

            //string filename = @"(765)(test) [HERE (qq)] we are the world";
            string filename = @"[fin] HERE [0710][tv][12]";
        }



        public static string yy(List<char> keywords,string filename)
        {
            string name = null;
            int position = 0;
            for (int i = 0; i < keywords.Count; i++)
            {
                char currentKey = keywords[i];
                char nextKey = keywords.ElementAtOrDefault(i + 1);
                for (int j = position; j < filename.Length; j++)
                {
                    if (currentKey.Equals('s'))
                    {
                        for (int k = j; k < filename.Length; k++)
                        {
                            if (filename[k].Equals(nextKey))
                            {
                                j = k;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        position = j;
                        break;
                    }
                    else if (currentKey.Equals('n'))
                    {
                        for (int k = j; k < filename.Length; k++)
                        {
                            if (filename[k].Equals(nextKey))
                            {
                                name = filename.Substring(j, k - j);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;
                    }
                    else if (currentKey.Equals(filename[j]))
                    {
                        position = j + 1;
                        break;
                    }
                    else
                    {
                        //throw exception
                    }
                }
                if (name != null) break;
            }
            name.ToString();
            return name;
        }
    }

    class  tt
    {
        readonly string SKIP="skip";
        readonly string NAME = "name";

        public List<char> ss(string format)
        {
            // \(s\)\(s\) \[n \(s\)\]s
            List<string> keywords = new List<string>();


            for (int i = 0; i<format.Length; i++)
            {
                string c = format[i].ToString();
                if (c.Equals("s",StringComparison.OrdinalIgnoreCase))
                {
                    var skip = "skip";
                    var code = hh(format, i, skip);
                    keywords.Add(code);
                }
                else if (c.Equals("n",StringComparison.OrdinalIgnoreCase))
                {
                    var name = "name";
                    var r = format.IndexOf(name,i);
                    if (!r.Equals(i)) continue;
                    var code = text.Substring(start, target.Length);
                }
                else
                {
                    keywords.Add(c);
                }
            }
            return keywords;
        }


        private string hh(string text,int start,string target)
        {
            var r = text.IndexOf(target, start);
            if (!r.Equals(start)) return null;
            var code = text.Substring(start, target.Length);
            return code;
        }
    }
}
