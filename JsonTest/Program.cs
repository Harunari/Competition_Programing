using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace JsonTest
{
    // 属性を付けないとプロパティ名がそのままJsonのキーになる

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person
            {
                Name = "Osaki Ryoya",
                Age = 31
            };

            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            {
                var serializer = new DataContractJsonSerializer(typeof(Person));
                serializer.WriteObject(ms, p);
                ms.Position = 0;

                var json = sr.ReadToEnd();
                Console.WriteLine($"{json}");
                Console.ReadLine();
            }
        }
    }
}
