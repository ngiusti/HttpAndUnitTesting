using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;



namespace HTTPProject
{
    public class UniqueWords
    {
        public string[] UniqueTitleWords { get; set; }
        public string[] UniqueBodyWords { get; set; }

        public static UniqueWords ListCreation()
        {
            List<string> titles = new List<string>();
            List<string> bodies = new List<string>();

            string textFromFile = System.IO.File.ReadAllText(@"C:\Users\Nick\Desktop\WriteLines.json");

            JArray PostsArray = JArray.Parse(textFromFile);

            IList<Values> Posts = PostsArray.Select(p => new Values
            {
                userId = (int)p["userId"],
                id = (int)p["id"],
                title = (string)p["title"],
                body = (string)p["body"],
            }).ToList();

            for (int i = 0; i < Posts.Count; i++)
            {
                titles.Add(Posts[i].title.ToString());
                bodies.Add(Posts[i].body.ToString());
            }


            var titlesArray = string.Join(" ", titles.ToArray()).Split(' ').Distinct().ToArray();
            var bodiesArray = string.Join(" ", bodies.ToArray()).Split(' ').Distinct().ToArray();
            var words = new UniqueWords();
            words.UniqueTitleWords = titlesArray;
            words.UniqueBodyWords = bodiesArray;

            return words; 
        }
    }


    public class Values
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }
}

