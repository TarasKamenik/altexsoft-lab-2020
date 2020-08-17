using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace task1
{
    class DelSymbol : FileProcessor
    {
        private string _filePath;
        public DelSymbol(string filePath) : base(filePath) 
        {
            _filePath = filePath;
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

            File.WriteAllText(_filePath, fileDataWithDeletedSymbol);
            Console.WriteLine(fileDataWithDeletedSymbol);
        }
    }
}
