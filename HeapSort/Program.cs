namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            int n = arr.Length;

            Sort(arr);
            Console.WriteLine(String.Join(",",arr));

        }
        static void Sort(int[] arr)
        {
            int n = arr.Length;

            //Построение кучи(операция heapify)
            for (int i = n/2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Один за другим извлекаем элементы из кучи
            for (int i = n-1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                Heapify(arr, i, 0);
            }
        }
        // Преобразование в двоичную кучу
        static void Heapify(int[]arr, int n, int i)
        {
            int largest = i; // Корневой элемент 

            // Инициализируем наибольший элемент как корень
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Если левый дочерний элемент больше корня
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if(right < n && arr[right] > arr[largest])
            {
                largest = right;
            }
            
            // Если самый большой элемент не корень 
            if(largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
            }

            // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
            Heapify(arr, n, largest);
        }
    }
}