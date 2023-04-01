using System;
using System.Diagnostics;


namespace lab1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Сортировка выбором
			
			int[] array = new int[4];
			var arr = GenerateDights(array);
			
			Stopwatch stopwatch = Stopwatch.StartNew();
			
			stopwatch.Start();
			SortArray(arr);
			stopwatch.Stop();

			Console.WriteLine(stopwatch.ElapsedMilliseconds);
		}

		public static int[] GenerateDights(int[] array)
		{
			var rand = new Random();
		
			for(int i = 0; i < array.Length; i++)
			{
				array[i] = rand.Next(1,101);
			}
			return array;
		}
		public static int[] SortArray(int[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				// Поиск минимального числа

				int min = i;

				for (int j = i + 1; j < array.Length; j++)
				{
					// Если последующее число меньше предыдущего, то min = индексу последующего 
					if (array[j] < array[min])
					{
						min = j;
					}
				}
				// Перестановка элементов
				int temp = array[min];
				array[min] = array[i];
				array[i] = temp;
			}
			return array;
		}
	}
}