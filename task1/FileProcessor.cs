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
        
    }
        

}
