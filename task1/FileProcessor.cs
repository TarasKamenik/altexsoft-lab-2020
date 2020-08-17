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
        protected string FileData { get; }

        public FileProcessor(string filePath)
        {
            
            if (File.Exists(filePath))
            {
                FileData = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
        
    }
        

}
