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
            string s = @"[skip] name [skip]s";

            var r= new tt().ParseFormat(s);
            r.ToString();

            //string filename = @"(765)(test) [HERE (qq)] we are the world";
            string filename = @"[fin] HERE [0710][tv][12]";
        }



        
    }

    class tt
    {
        readonly string SKIP = "skip";
        readonly string NAME = "name";

        string[] codes = new string[] { "skip", "name" };

        public List<string> ParseFormat(string format)
        {
            // \(s\)\(s\) \[n \(s\)\]s
            List<string> keywords = new List<string>();
            for (int i = 0; i < format.Length; i++)
            {
                char c = format[i];

                if ((65 <= c && c <= 90) || (97 <= c && c <= 122))
                {
                    foreach (var code in codes)
                    {
                        if (format.IndexOf(code, i, StringComparison.OrdinalIgnoreCase).Equals(i))
                        {
                            var r = format.Substring(i, code.Length);
                            keywords.Add(r);
                        }
                    }
                }
                else
                {
                    keywords.Add(c.ToString());
                }
            }
            return keywords;
        }

        public string yy(List<string> keywords, string filename)
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
}
