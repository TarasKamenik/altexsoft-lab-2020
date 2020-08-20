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
			if (string.IsNullOrEmpty(symbol))
			{
				return;
			}

			if (FileData.Contains(symbol))
			{
				string ext = ".txt";
				string textFileNameCopy = Path.GetFileNameWithoutExtension(_filePath) + "_copy" + ext;
				File.Copy(_filePath, textFileNameCopy, true);
				var fileDataWithDeletedSymbol = FileData.Replace(symbol, "", true, CultureInfo.CurrentCulture);
				File.WriteAllText(_filePath, fileDataWithDeletedSymbol);
				Console.WriteLine(fileDataWithDeletedSymbol);
			}
			else
				Console.WriteLine($"Ошибка - в тексте нет указаного символа\\слова {symbol}");
		}
	}
}