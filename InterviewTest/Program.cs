using System;

namespace InterviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
             int[] values = { 1, 4, 3, 2 };
            //int[] values = { 2, 3, 4, 5, 1 };
            var result = inversePermutation(values);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
            }
            Console.ReadLine();
        }

        private static int[] inversePermutation(int[] array)
        {
            
            int[] inversedParmutatedArray = new int[array.Length];
            
            for (int i = 0; i < array.Length; i++)
            {
                int valueInPosition = array[i];

                inversedParmutatedArray[valueInPosition -1] = i + 1;
               
            }
            return inversedParmutatedArray;
        }
    }
}
 