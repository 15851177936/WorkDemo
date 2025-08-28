using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WorkDemo
{
    internal class YamlHelper
    {
        public static bool WriteToYaml<T>(string file, T obj)
        {
            return SerializeToFile(file, obj);
        }

        public static string Serialize<T>(T target)
        {
            var _serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            return _serializer.Serialize(target);
        }

        public static bool SerializeToFile<T>(string filePath, T target)
        {
            var content = Serialize(target);
            File.WriteAllText(filePath, content, Encoding.UTF8);
            return true;
        }

        public static T ReadYaml<T>(string file)
        {
            var target = DeserializeFromFile<T>(file);
            return target;
        }

        public static T Deserialize<T>(string yaml)
        {
            IDeserializer _deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
            return _deserializer.Deserialize<T>(yaml);
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            var yaml = File.ReadAllText(filePath, Encoding.UTF8);
            return Deserialize<T>(yaml);
        }
    }
}
