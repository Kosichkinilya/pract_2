using System;
using LibArray;

namespace Lib_8
{
    public static class ExtensionArray
    {
        public static void Fill(this Array<int> numbers)
        {
            Random rnd = new();
            for (int i = 0; i < numbers.Capacity; i++)
            {
                numbers.Add(rnd.Next(1, 100));
            }
        }

        public static void Difference(this Array<int> numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Capacity; i++)
            {
                if(numbers[i] < 3)
                {
                    sum += numbers[i];
                }
            }
            Math.Cos(sum);
        }
    }
}
