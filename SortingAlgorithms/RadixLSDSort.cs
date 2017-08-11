class Sort
{
    //неотсортированый массив
    static int[] numbers = { 5, 2, 12, 7, 452, 256 };

    static void Main(string[] args)
    {
        while (true)
        {
            RadixLSDsort(numbers, 10, 3);
            Console.ReadLine();
        }
    }

    static void RadixLSDsort(int[] arrLSD, int range, int length)
    {
        // Создание листов в зависимости от переменной range, переменная range отвечает за количество возможных значение разряда.
        // В нашем случае это 10 (от 0 до 9).
        ArrayList[] lists = new ArrayList[range];
        for (int i = 0; i < range; ++i)
        {
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

        // Вывод отсортированого массива.
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
}
