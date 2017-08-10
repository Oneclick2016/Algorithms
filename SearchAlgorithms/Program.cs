using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static int[] arr = { 1, 5, 6, 11, 12, 17 };
        
        //неотсортированый массив
        static int[] numbers = { 5, 2, 12, 7, 452 };

        static void Main(string[] args)
        {
            //BSearch(6);
            while (true)
            {
                //Console.WriteLine("\n\nВведите число");
                //int input = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Введите разряд");
                //int radix = Convert.ToInt32(Console.ReadLine());
                //RadixLSD(input);
                //RadixSearch(input, radix);

                //Console.WriteLine("\n\nВведите  1 число");
                //int input1 = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Введите  2 число");
                //int input2 = Convert.ToInt32(Console.ReadLine());
                //Crat(input1, input2);

                RadixLSDsort(numbers, 10, 3);
                Console.ReadLine();
            }
            
            
        }

        static void BSearch(int searchNumber)
        {
            int min = 0;
            int max = arr.Length - 1;
            int middle;

            while (min <= max)
            {
                middle = (min + max) / 2;
                if (searchNumber == arr[middle])
                {
                    Console.WriteLine("Ваше число " + searchNumber + "\nНаходится под индексом " + middle + "\n");
                    return;
                }
                else if (searchNumber > arr[middle])
                {
                    min = middle + 1;
                }
                else
                {
                    max = middle- 1;
                }

            }
            Console.WriteLine("Числа нет в массиве");
        }

        static void RadixLSD(int input)
        {
            int radix = 1;
            int radixIn = 1;
            while (input >= 1)
            {
                radixIn = input % 10;
                Console.WriteLine(radix + " разряд равен " + radixIn);

                radix++;
                input /= 10;
            }
            radix--;
            Console.WriteLine("В числе столько разрядов: " + radix + "\n");
         }

        static void RadixLSDsort(int[] arrLSD, int range, int length)
        {
            // Создание листов в зависимости от переменной range, переменная range отвечает за количество возможных значение разряда.
            // В нашем случае это 10 (от 0 до 9).
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i) { 
                lists[i] = new ArrayList();
            }

            for (int radix = 1; radix <= length; radix++)
            {
                // Разброс элементов начального массива по листам по разрядам.
                for (int i = 0; i < arrLSD.Length; ++i)
                {
                    int temp = (int)Char.GetNumericValue(RadixSearch(arrLSD[i], radix));
                    //int temp = int.Parse(RadixSearch(arrLSD[i], radix).ToString()); второй вариант
                    lists[temp].Add(arrLSD[i]);
                }

                // Сборка массива из листов.
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arrLSD[k++] = (int)lists[i][j];
                    }
                }

                // Отчистка листов.
                for (int i = 0; i < range; ++i) { lists[i].Clear(); }
            }

            Console.WriteLine("Показываем весь массив");
            for (int i = 0; i < arrLSD.Length; i++)
            {
                Console.Write(arrLSD[i] + " ");
            }
        }

        static char RadixSearch(int input, int radixNumber)
        {
            var output = input.ToString().Reverse().ToList();
            try
            {
                //Console.WriteLine(radixNumber + " разряд этого числа " + input + " равен " + output[radixNumber - 1]);
                return output[radixNumber - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                //Console.WriteLine(radixNumber + " разряд этого числа " + input + " равен 0");
                return '0';
            }
        }

        static void Crat(int one, int two) // 2 13
        {
            // two 13 1 one 2 0
            int d = one * two; // 26
            while (one != 0 && two != 0){
                if(one > two) 
                {
                    one %= two;
                }
                else 
                {
                    two %= one;
                }   
            }
            int result = d / (two + one);
            Console.WriteLine(result);
        }

    }
}
