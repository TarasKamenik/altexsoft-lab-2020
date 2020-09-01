using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace task1
{
	public class DirectoriesProcessor
	{
		public void RunDirectoriesLogic()
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
	}
}
