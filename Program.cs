using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Diagnostics;


namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для анализа текста");
            Console.WriteLine("Введите текст:");

            string text = Console.ReadLine();
            Console.WriteLine("Количество символов: "+ text.Length);
                 

            string[] words = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int countWords = words.Length;
            Console.WriteLine("Количество слов: " + countWords);

            string[] sentences = text.Split(".?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int count = sentences.Length;
            Console.WriteLine("Количество предложений: "+count);

            string[] sentencesQ = text.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries-1);
            int countSentencesQ = sentencesQ.Length;
            Console.WriteLine("Количество восклицательных предложений: " +(countSentencesQ -1));

            string[] sentencesE = text.Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries-1);
            int countSentencesE = sentencesE.Length;
            Console.WriteLine("Количество вопросительных предложений: " +(countSentencesE-1));


            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
            var matches = Regex.Matches(text, @"[-+]?\d+(?:\.\d+)?(?:[eE][-+]?\d+)?");
            var sum = 0.0;
            foreach (Match items in matches)
            {
                sum += double.Parse(items.Value);
            }
            Console.WriteLine("Общая сумма чисел в тексте равна: " + sum);

            Console.WriteLine("Введите название файла, что бы сохранить данные");
            string name = Console.ReadLine();
            File.WriteAllText
                (name+".txt", " Количество символов: "+ text.Length + "," + 
                " Количество слов: " + countWords+"," + " Количество предложений: " + count + "," +
                " Количество восклицательных предложений: " +(countSentencesQ -1) + "," + 
                " Количество вопросительных предложений: " +(countSentencesE - 1)+".");
            Process.Start(name + ".txt");
            
        }
    }
}
