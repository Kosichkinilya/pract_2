using System;
using LibArray;

namespace Lib_8
{
    public static class ExtensionArray
    {
        /// <summary>
        /// ������� ���������� ������ �� 1 �� 100
        /// </summary>
        /// <param name="numbers">������ ��� ����������</param>
        public static void Fill(this Array<int> numbers, int min = -10, int max = 11) 
        {
            Random rnd = new();
            for (int i = 0; i < numbers.Capacity; i++)
            {
                numbers.Add(rnd.Next(min, max));
            }
        }
        /// <summary>
        /// ������� ����� ��������� ������� < 3 
        /// </summary>
        /// <param name="numbers">������ ��� ����������</param>

        public static double Calculation(this Array<int> numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Capacity; i++)
            {
                if(numbers[i] < 3)
                {
                    sum += numbers[i];
                }
            }
            return Math.Cos(sum);
        }
    }
}
