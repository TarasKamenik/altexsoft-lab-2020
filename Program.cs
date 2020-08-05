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
        static string TextFileName = @"Text1.txt";
        public static void Main(string[] args)
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


                 FileProcessor fileProcessor = new FileProcessor(TextFileName);
                 if (useDeleteSymbol) 
                     fileProcessor.DeleteSymbol();
                 if (useWordsCountAndEvery10)
                     fileProcessor.WordsCountAndEvery10();
                 if (useThirdSentence)
                     fileProcessor.ThirdSentence();

                 DerectoriesProcessor derectories = new DerectoriesProcessor();
                 if (useDirectories)
                     derectories.Directories();
                                     
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }










    }
}

 

