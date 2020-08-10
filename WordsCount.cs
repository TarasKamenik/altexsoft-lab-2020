using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task1
{
    class WordsCount : FileProcessor
    {
        public WordsCount(string filePath) : base(filePath) { }
        public void WordsCountAndEvery10()
        {
            string[] words = Regex.Split(FileData, @"\s+", RegexOptions.IgnoreCase);
            var wordsCount = words.Length;
            Console.WriteLine($"Количество слов в тексте:\n {wordsCount}");

            var every10Word = string.Join(", ", words
                .Where((x, i) => (i + 1) % 10 == 0)
                .Select(w => w.Trim(',', ';', '.', ':', '?', '(', ')', '!', '"', '\n', '\t'))
                .ToList());
            Console.WriteLine($"Каждое десятое - {every10Word}");
        }

    }
}
