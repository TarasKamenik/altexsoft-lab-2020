using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task1
{
    public class FileProcessor
    {
        public string FileData;

        public FileProcessor(string filePath)
        {
            
            if (File.Exists(filePath))
            {
                File.Copy(@"Text1.txt", @"Text1_copy.txt", true);
                FileData = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
        
        public void DeleteSymbol()
        {
            Console.WriteLine($"Введите символ\\слово:");
            var symbol = Console.ReadLine();

            var fileDataWithDeletedSymbol = "";
            if (!string.IsNullOrEmpty(symbol) && FileData.Contains(symbol))
                fileDataWithDeletedSymbol = FileData.Replace(symbol, "", true, CultureInfo.CurrentCulture);
            else
                Console.WriteLine($"Ошибка - в тексте нет указаного символа\\слова {symbol}");

            File.WriteAllText("Text1.txt", fileDataWithDeletedSymbol);
            Console.WriteLine(fileDataWithDeletedSymbol);
        }

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

        public void ThirdSentence()
        {
            string[] sentences = Regex.Split(FileData, @"[.!?]", RegexOptions.CultureInvariant);
            if (sentences.Length >= 2)
            {
                var reversedWords = string.Join(' ', sentences[2].Split(' ').Select(word => Reverse(word)));
                Console.WriteLine($"3е предложение в обратном порядке:\n{reversedWords}");
            }
            else
            {
                Console.WriteLine($"Ошибка - нет 3го предложения");
            }
        }
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
        

}
