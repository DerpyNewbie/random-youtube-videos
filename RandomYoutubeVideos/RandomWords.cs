using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RandomYoutubeVideos
{
    public static class RandomWords
    {
        private static List<string> _words;

        public static void Initialize()
        {
            Console.Out.WriteLine("Parsing words");
            _words = new List<string>(JArray.Parse(File.ReadAllText(@"words.json")).Values<string>());
            Console.Out.WriteLine("Parsed words count of {0}", _words.Count);
        }

        public static string GetWord(int i)
        {
            return _words[i];
        }

        public static string GetRandomWord()
        {
            return GetWord(new Random().Next(GetWordsLength()));
        }

        public static string GetRandomWords(int length)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
                builder.Append(GetRandomWord()).Append(" ");

            return builder.ToString().Trim();
        }

        public static int GetWordsLength()
        {
            return _words.Count;
        }
    }
}