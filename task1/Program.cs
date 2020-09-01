using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace task1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите имя файла вместе с расширением:");

			string textFileName = Console.ReadLine();
			
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
					Console.WriteLine($"Исполнять удаление символа? (Y/n)");
					useDeleteSymbol = Console.ReadKey().Key == ConsoleKey.Y;
					Console.WriteLine();

					Console.WriteLine($"Выводить каждое десятое слово? (Y/n)");
					useWordsCountAndEvery10 = Console.ReadKey().Key == ConsoleKey.Y;
					Console.WriteLine();

					Console.WriteLine($"Выводить третье предложение? (Y/n)");
					useThirdSentence = Console.ReadKey().Key == ConsoleKey.Y;
					Console.WriteLine();

					Console.WriteLine($"Выводить содержимое папки? (Y/n)");
					useDirectories = Console.ReadKey().Key == ConsoleKey.Y;
					Console.WriteLine();
				}

				if (useDeleteSymbol)
				{
					SymbolRemover symbolRemover = new SymbolRemover(textFileName);
					symbolRemover.DeleteSymbol();
				}

				if (useWordsCountAndEvery10)
				{
					WordsCounter wordsCounter = new WordsCounter(textFileName);
					wordsCounter.CountWordsAndShowEvery10();
				}

				if (useThirdSentence)
				{
					ThirdSentenceModifier thirdSentenceModifier = new ThirdSentenceModifier(textFileName);
					thirdSentenceModifier.ModifyThirdSentence();
				}

				if (useDirectories)
				{
					DirectoriesProcessor directoriesProcessor = new DirectoriesProcessor();
					directoriesProcessor.RunDirectoriesLogic();
				}
			}
			catch (IOException e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}
		}
	}
}

