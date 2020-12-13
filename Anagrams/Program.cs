using System;
using System.Collections.Generic;

namespace Anagrams
{
    class Program
    {
        public static Dictionary<char, int> MakeDictionary(string message)
        {
            var letters = new Dictionary<char, int>();
            for (int i = 0; i < message.Length; i++)
            {
                if (!letters.ContainsKey(message[i]))
                {
                    letters.Add(message[i], 1);
                }
            }
            return letters;
        }

        public static bool IsAnagram(string userSelection, string anagram)
        {
            var letters = MakeDictionary(userSelection);
            bool correct = true;
            int i = 0;
            while(i < anagram.Length && correct)
            {
                if(!letters.ContainsKey(anagram[i]))
                {
                    correct = false;
                }
                i++;
            }
            return correct;
        }

        public static string CheckInput(string consoleMessage)
        {
            string message;
            Console.Write(consoleMessage);
            message = Console.ReadLine();
            for(int i = 0; i < message.Length; i++)
            {
                if(message[i] < 'a' || message[i] > 'z')
                {
                    message = message.Replace(message[i].ToString(), "");
                }
            }
           
            return message;
        }

        static void Main(string[] args)
        {

            string userSelection = "A";
            string anagram = "A";
            do
            {
                userSelection = CheckInput("Enter a word without special character ");
                anagram = CheckInput("Enter an anagram to the word without special character ");

            } while (userSelection == "" || anagram == "");
            

            if (IsAnagram(userSelection.ToLower(), anagram.ToLower()))
            {
                Console.WriteLine("{1} is an anagram to {0}", anagram, userSelection);
            }
            else
            {
                Console.WriteLine("{1} is not an anagram to {0}", anagram, userSelection);
            }
        }
    }
}
