using System.Diagnostics;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] numbers = new int[4];
            GenerateDights(numbers);
            
            sw.Start();
            // В параметры помещаем массив, минимальный индекс, и указываем на конец массива(не берем опорный элемент)
            numbers = QuickSort(numbers, 0, numbers.Length - 1);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            
        }
        static int[] GenerateDights(int[] array)
        {
            var rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 101);
            }
            return array;
        }
        static int FindPivot(int[] numbers, int minIndex,int maxIndex)
        {
            int temp = 0;
            // Опорный элемент - последний в массиве
            int pivot = minIndex - 1;

            //Обходим массив до предпоследнего элемента

            for (int i = minIndex; i < maxIndex; i++)
            {
                // Сравниваем каждый элемент с последним элементом, если меньше - то индекс опорного прибавляем
                if (numbers[i] < numbers[maxIndex])
                {
                    pivot++;
                    temp = numbers[pivot];
                    numbers[pivot] = numbers[i];
                    numbers[i] = temp;
                }
            }
            pivot++;
            temp = numbers[pivot];
            numbers[pivot] = numbers[maxIndex];
            numbers[maxIndex] = temp;

            return pivot;
        }
        static int[] QuickSort(int[] numbers, int minIndex, int maxIndex)
        {
            //
            if(minIndex >= maxIndex)
            {
                return numbers;
            }

            int pivot = FindPivot(numbers, minIndex, maxIndex);
            QuickSort(numbers, minIndex, pivot - 1);
            QuickSort(numbers, pivot + 1, maxIndex);

            return numbers;
        }
    }
} 