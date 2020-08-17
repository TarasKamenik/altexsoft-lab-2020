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
            Console.WriteLine("ВВедите имя файла:");

            string path1 = Console.ReadLine();
            string ext = ".txt";
            string TextFileName = path1 + ext;
            string TextFileNameCopy = path1 + "_copy" + ext;
            File.Copy(TextFileName, TextFileNameCopy, true);

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


                
                if (useDeleteSymbol) 
                {
                    DelSymbol delSymbol = new DelSymbol(TextFileName);
                    delSymbol.DeleteSymbol();
                }
                    

                if (useWordsCountAndEvery10) 
                {
                    WordsCount wordsCount = new WordsCount(TextFileName);
                    wordsCount.WordsCountAndEvery10();
                }
                    

                if (useThirdSentence) 
                {
                    Sentence sentence = new Sentence(TextFileName);
                    sentence.ThirdSentence();
                }
                    

                if (useDirectories) 
                {
                    DerectoriesProcessor derectories = new DerectoriesProcessor();
                    derectories.Directories();
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

 

