using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    class Filesystem
    {
        private string fileName = "./data.json";

        public List<Member> getData()
        {
            if (!File.Exists(fileName))
            {
                var data = new List<Member>();
                saveData(data);
                throw new System.Exception("data.json don't exist creating new. Please restart the program");
            }
            else
            {
                var data = File.ReadAllText(fileName);
                return new List<Member>
                    (JsonConvert.DeserializeObject<List<Member>>(data));
            }
        }

        public void saveData(List<Member> members)
        {
            var data = JsonConvert.SerializeObject(members);
            File.WriteAllText(fileName, data);
        }
    }
}
