class Search
{
    static int[] numbers = { 1, 5, 6, 11, 12, 17 };

    static void Main(string[] args)
    {
        BSearch(numbers, 6);
    }

    static void BSearch(int[] arr, int searchNumber)
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
                max = middle - 1;
            }
        }
        Console.WriteLine("Числа нет в массиве");
    }
}
