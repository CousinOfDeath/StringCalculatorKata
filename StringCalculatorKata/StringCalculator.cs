using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            if (IsDefault(numbers))
            {
                return GetDefaultValue();
            }

            if (HasMultipleNumers(numbers))
            {
                return GetSum(numbers);
            }
            
            return ParseSingle(numbers);
        }

        protected virtual int ParseSingle(string numbers)
        {
            var num = int.Parse(numbers);

            CheckThatNumberIsPositive(num);
            
            return num <= 1000 ? num : 0;
        }

        protected virtual void CheckThatNumberIsPositive(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException($"negatives not allowed: {num}");
            }
        }

        protected virtual int GetSum(string numbers)
        {

            var delimiters = new List<string>
            {
                "\n"
            };
            
            if (numbers.StartsWith("//"))
            {
                var customDelimiter = numbers.Substring(2, 1);
                delimiters.Add(customDelimiter);

                numbers = numbers.Substring(4, numbers.Length - 4);
            }

            foreach (var delimiter in delimiters)
            {
                numbers = numbers.Replace(delimiter, ",");  
            }

            var numbersString = numbers.Split(',');
            var numbersInt = numbersString.Select(int.Parse);
            var negativeNumbers = numbersInt.Where(n => n < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
            
            return numbersString.Select(int.Parse).Where(n => n <= 1000).Sum();
        }

        protected virtual bool HasMultipleNumers(string numbers)
        {
            
            return numbers.Contains(",") || numbers.StartsWith("//");
        }

        protected virtual int GetDefaultValue()
        {
            return 0;
        }

        protected virtual bool IsDefault(string numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }
    }
}