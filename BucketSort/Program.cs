using System.Diagnostics;

namespace BucketSort
{
	class Program
	{
		static void Main(string[]args)
		{
			Stopwatch sw = new Stopwatch();
			int[] arr = new int[4000];
			Random rand = new Random();
			
			for(int i = 0; i < arr.Length; i++)
			{
				arr[i] = rand.Next(1,101);
			}
			
			sw.Start();
			BucketSort(arr);
			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);
		}
		static void BucketSort(int[] a)
		{
			// Количество корзин равно количеству элементов в массиве
			List<int>[] aux = new List<int>[a.Length];

			// Инициализация каждой корзины(Каждая корзина - новый лист)

			for(int i = 0; i < a.Length; i++)
			{
				aux[i] = new List<int>();
			}

			// Поиск диапазона значений
			int maxValue = a[0];
			int minValue = a[0];

			//Цикл для поиска минимального и максимального значений 
			for(int i = 1; i < a.Length; i++)
			{
				if (a[i] > maxValue)
				{
					maxValue = a[i];
				}
				if (a[i] < minValue)
				{
					minValue = a[i];
				}
			}

			//Разница между максимальным и минимальным значениями 
			double numRange = maxValue - minValue;

			//Добавление нужного элемента в нужную корзину по индексу 
			for(int i = 0; i < a.Length; i++)
			{
				int bcktInd = (int)Math.Floor((a[i] - minValue) / numRange * (aux.Length - 1));

				aux[bcktInd].Add(a[i]);
			}

            for (int i = 0; i < aux.Length; ++i)
			{
                aux[i].Sort();
            }
                
            //Собираем отсортированные элементы обратно в исходный массив
            int idx = 0;

			for(int i = 0; i < a.Length; i++)
			{
				for(int j = 0; j < aux[i].Count; j++)
				{
					a[idx++] = aux[i][j];
				}
			}
		}
	}
}