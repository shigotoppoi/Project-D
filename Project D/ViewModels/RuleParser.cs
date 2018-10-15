using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.ViewModels
{
    internal class RuleParser
    {

        private readonly string SKIP = "skip";
        private readonly string NAME = "name";
        private string[] codes = new string[] { "skip", "name" };

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

        public string ParseName(List<string> formatKeys, string name)
        {
            string result = null;
            int filenameIndex = 0;
            for (int i = 0; i < formatKeys.Count; i++)
            {
                string currentKey = formatKeys[i];
                string nextKey = formatKeys.ElementAtOrDefault(i + 1);
                for (; filenameIndex < name.Length; filenameIndex++)
                {
                    var nameF = name[filenameIndex].ToString();
                    if (currentKey.Equals("skip", StringComparison.OrdinalIgnoreCase))
                    {
                        if (nameF.Equals(nextKey))
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (currentKey.Equals("name", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = filenameIndex; j < name.Length; j++)
                        {
                            var nameJ = name[j].ToString();
                            if (nameJ.Equals(nextKey))
                            {
                                result = name.Substring(filenameIndex, j - filenameIndex);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;
                    }
                    else if (currentKey.Equals(nameF))
                    {
                        filenameIndex = filenameIndex + 1;
                        break;
                    }
                    else
                    {
                        //throw exception
                    }
                }

                if (result != null) break;
            }

            return result;
        }
    }
}
