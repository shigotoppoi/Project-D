using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    internal class RuleParser
    {

        private readonly string SKIP = "skip";
        private readonly string NAME = "name";
        private string[] codes => new string[] { SKIP, NAME };

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
            int nameIndex = 0;
            for (int i = 0; i < formatKeys.Count; i++)
            {
                string currentKey = formatKeys[i].ToLower();
                string nextKey = formatKeys.ElementAtOrDefault(i + 1);
                for (; nameIndex < name.Length; nameIndex++)
                {
                    var fStr = name[nameIndex].ToString();
                    if (currentKey.Equals(SKIP))
                    {
                        if (fStr.Equals(nextKey))
                        {
                            break;
                        }
                        continue;
                    }
                    else if (currentKey.Equals(NAME))
                    {
                        for (int j = nameIndex; j < name.Length; j++)
                        {
                            var jStr = name[j].ToString();
                            if (jStr.Equals(nextKey))
                            {
                                result = name.Substring(nameIndex, j - nameIndex);
                                break;
                            }
                        }
                        break;
                    }
                    else if (currentKey.Equals(fStr))
                    {
                        nameIndex = nameIndex + 1;
                        break;
                    }
                    else
                    {
                        //todo throw exception
                    }
                }

                if (result != null) break;
            }

            return result;
        }
    }
}
