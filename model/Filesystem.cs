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
            var data = File.ReadAllText(fileName);
            return new List<Member>
                (JsonConvert.DeserializeObject<List<Member>>(data));
        }

        public void SaveData(List<Member> members)
        {
            var data = JsonConvert.SerializeObject(members);
            File.WriteAllText(fileName, data);
        }
    }
}
