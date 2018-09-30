using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    class Filesystem
    {
        private string fileName = "./data.json";

        public List<Member> GetData()
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("#########################################################");
                Console.WriteLine("   WARNING: ./data.json don't exist creating new.");
                Console.WriteLine("#########################################################");

                var data = new List<Member>();
                SaveData(data);
                return data;
            }
            else
            {
                var data = File.ReadAllText(fileName);
                return new List<Member>
                    (JsonConvert.DeserializeObject<List<Member>>(data));
            }
        }

        public void SaveData(List<Member> members)
        {
            var data = JsonConvert.SerializeObject(members);
            File.WriteAllText(fileName, data);
        }
    }
}
