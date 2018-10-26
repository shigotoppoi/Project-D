using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_D.ViewModels;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {

        }
    }


    class MyTest
    {
        RuleViewModel _getRule() => new RuleViewModel
        {
            CreateIfNone = true,
            Destination = "SSS",
            ReplaceIfExist = true,
            Extensions = "zip;jpg;png",
            Format = "[skip] name [skip]",
            Name = "MYTEST"
        };

        IEnumerable<StorageViewModel> _getStorages()
        {
            return new List<StorageViewModel>
            {
                new StorageViewModel{Extension="jpg",Name="AAA",Path="aaa"},
                new StorageViewModel{Extension="jpg",Name="AAA",Path="aaa"},
                new StorageViewModel{Extension="jpg",Name="AAA",Path="aaa"},
                new StorageViewModel{Extension="jpg",Name="AAA",Path="aaa"},
            };
        }


        public async Task TestStorageDispatcher()
        {
            await new StorageDispatcher(_getStorages(), _getRule()).RunAsync();
        }
    }

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

        public string ParseFilename(List<string> keywords, string filename)
        {
            string name = null;
            int filenameIndex = 0;
            for (int i = 0; i < keywords.Count; i++)
            {
                string currentKey = keywords[i];
                string nextKey = keywords.ElementAtOrDefault(i + 1);
                for (; filenameIndex < filename.Length; filenameIndex++)
                {
                    if (currentKey.Equals("skip", StringComparison.OrdinalIgnoreCase))
                    {
                        if (filename[filenameIndex].Equals(nextKey))
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
                        for (int j = filenameIndex; j < filename.Length; j++)
                        {
                            if (filename[j].Equals(nextKey))
                            {
                                name = filename.Substring(filenameIndex, j - filenameIndex);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;
                    }
                    else if (currentKey.Equals(filename[filenameIndex]))
                    {
                        filenameIndex = filenameIndex + 1;
                        break;
                    }
                    else
                    {
                        //throw exception
                    }
                }

                if (name != null) break;
            }

            return name;
        }
    }
}
