using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsolText
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var useDeleteSymbol = false;
                var useWordsCountAndEvery10 = false;
                var useThirdSentence = false;
                var useDirectories = false;

                if (args != null && args.Length > 0)
                {
                    useDeleteSymbol = args.Contains("DeleteSymbol");
                    useWordsCountAndEvery10 = args.Contains("WordsCountAndEvery10");
                    useThirdSentence = args.Contains("ThirdSentence");
                    useDirectories = args.Contains("Directories");
                } 
                else
                {
                    Console.WriteLine($"Исполнять метод DeleteSymbol? (Y/n)");
                    useDeleteSymbol = Console.ReadKey().KeyChar == 'Y';
                    Console.WriteLine(); 

                    Console.WriteLine($"Исполнять метод WordsCountAndEvery10? (Y/n)");
                    useWordsCountAndEvery10 = Console.ReadKey().KeyChar == 'Y';
                    Console.WriteLine();

                    Console.WriteLine($"Исполнять метод ThirdSentence? (Y/n)");
                    useThirdSentence = Console.ReadKey().KeyChar == 'Y';
                    Console.WriteLine();

                    Console.WriteLine($"Исполнять метод Directories? (Y/n)");
                    useDirectories = Console.ReadKey().KeyChar == 'Y';
                    Console.WriteLine();
                }

                File.Copy(@"Text1.txt", @"Text1_copy.txt", true);
                var fileData = "";
                using (var fileReader = new StreamReader("Text1.txt"))
                {
                    fileData = await fileReader.ReadToEndAsync();
                    fileReader.Close();
                }

                if (useDeleteSymbol)
                    DeleteSymbol(fileData);

                if (useWordsCountAndEvery10)
                    WordsCountAndEvery10(fileData);

                if (useThirdSentence)
                    ThirdSentence(fileData);

                if (useDirectories)
                    Directories();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteSymbol(string fileData)
        {
            Console.WriteLine($"Введите символ\\слово:");
            var symbol = Console.ReadLine();

            var fileDataWithDeletedSymbol = "";
            if (!string.IsNullOrEmpty(symbol) && fileData.Contains(symbol))
                fileDataWithDeletedSymbol = fileData.Replace(symbol, "", true, CultureInfo.CurrentCulture);
            else
                Console.WriteLine($"Ошибка - в тексте нет указаного символа\\слова {symbol}");

            using var writerStream = new StreamWriter("Text1.txt", false);
            writerStream.Write(fileDataWithDeletedSymbol);
            writerStream.Flush();
            writerStream.Close();
        }

        private static void WordsCountAndEvery10(string fileData)
        {
            var words = fileData.Split(' ');
            var wordsCount = words.Length;
            Console.WriteLine($"Количество слов в тексте:\n {wordsCount}");

            var every10Word = string.Join(", ", words
                .Where((x, i) => (i + 1) % 10 == 0)
                .Select(w => w.Trim(',', ';', '.', ':', '?', '(', ')', '!', '"', '\n', '\t'))
                .ToList());
            Console.WriteLine($"Каждое десятое - {every10Word}");
        }

        private static void ThirdSentence(string fileData)
        {
            var sentences = fileData.Split('.', '!', '?');
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

        private static void Directories()
        {
            Console.WriteLine($"Введите путь:");
            string folderPath = Console.ReadLine();

            if (string.IsNullOrEmpty(folderPath))
            {
                Console.WriteLine("Не введен путь");
                return;
            }

            var folders = Directory.GetDirectories(folderPath);
            folders = folders.OrderBy(f => f).ToArray();
            for (int i = 0; i < folders.Length; i++)
            {
                string folder = folders[i];
                Console.WriteLine($"{i} - {folder}");
            }
            Console.WriteLine($"Введите индекс:");
            var idStr = Console.ReadLine();
            if (int.TryParse(idStr, out int id))
            {
                if (id < folders.Length)
                {
                    var files = Directory.GetFiles(folders[id]);
                    files = files.OrderBy(f => f).ToArray();
                    foreach (var item in files)
                    {
                        Console.WriteLine(item);
                    }

                }
                else
                {
                    Console.WriteLine("Нет такого идентификатора папки");
                }
            }
            else
            {
                Console.WriteLine("Введён неправильный идентификатор");
            }
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

 

