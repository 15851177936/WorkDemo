using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace WorkDemo
{
    internal class YamlClass
    {
        public class YamlClassCell
        {
            [YamlMember(Alias = "arraytest")]
            public string[] arraytest { get; set; }

            [YamlMember(Alias = "stringtest")]
            public string stringtest { get; set; }

            [YamlMember(Alias = "inttest")]
            public int inttest { get; set; }

            [YamlMember(Alias = "dictionarytest")]
            public Dictionary<string, string> dictionarytest { get; set; }
        }

        [YamlMember(Alias = "yamlclass")]
        public List<YamlClassCell> yamlClass { get; set; }
    }
}
