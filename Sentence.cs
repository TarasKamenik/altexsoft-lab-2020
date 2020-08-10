﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task1
{
    class Sentence : FileProcessor
    {
        public Sentence(string filePath) : base(filePath) { }
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
