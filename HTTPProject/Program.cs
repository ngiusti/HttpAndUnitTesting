using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace HTTPProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://jsonplaceholder.typicode.com/posts");
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            string text = null;

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response);


            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            System.IO.File.WriteAllText(@"C:\Users\Nick\Desktop\WriteLines.json", text);



            UniqueWords words = UniqueWords.ListCreation();
            
            

            Console.WriteLine(words.UniqueTitleWords[1]);
            return;
        }


    }
}
