﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new []{ ",", "\n" };
            var numbersOnly = numbers;

            if(numbers.StartsWith("//"))
            {
                if (numbers.StartsWith("//["))
                    delimiters = GetDelimiters(numbers);
                else
                    delimiters = new [] { numbers.Skip(2).First().ToString() };

                numbersOnly = new string(numbers.SkipWhile(c => c != '\n').ToArray());
            }

            var integers = numbersOnly
                            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => int.Parse(x))
                            .ToList();

            var negatives = integers.Where(i => i < 0).ToArray();

            if (negatives.Any())
                throw new ArgumentOutOfRangeException("numbers", 
                    string.Format("Negatives not allowed. Found: {0}.", string.Join(", ", numbers)));

            return integers.Where(i => i <= 1000).Sum();
        }

        private static string[] GetDelimiters(string numbers)
        {
            var s = numbers.Substring(2, numbers.IndexOf("]\n") - 1);
            var delimiters = new List<string>();

            while (s != "")
            {
                var closingBracketPosition = s.IndexOf("]");
                delimiters.Add(s.Substring(1, closingBracketPosition - 1));
                s = s.Substring(closingBracketPosition + 1);
            }

            return delimiters.ToArray();
        }
    }   
}
