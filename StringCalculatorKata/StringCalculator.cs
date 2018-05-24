using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            if (numbers.Contains(","))
            {
                var numbersString = numbers.Split(',');

                return numbersString.Select(int.Parse).Sum();

            }
            
            return int.Parse(numbers);
        }
    }
}