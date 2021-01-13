using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineCounter
{
    class StringCalculator
    {
        public int Calculate(string input, string mathOperator = "+", char delimeter = ',')
        {
            var num = 0;
            if (input.Length > 0)
            {
                var parts = input.Split(delimeter);
                
                for (var i = 0; i < parts.Length; i++)
                {
                    if (!int.TryParse(parts.ElementAt(i), out var operand))
                    {
                        throw new InvalidDataException($"Invalid input: {parts.ElementAt(i)}");
                    }

                    if (i == 0)
                    {
                        num = operand;
                        continue;
                    }

                    switch (mathOperator)
                    {
                        case "-":
                            num -= operand;
                            break;
                        default:
                            num += operand;
                            break;
                    }
                }
            }

            return num;
        }

    }
}
