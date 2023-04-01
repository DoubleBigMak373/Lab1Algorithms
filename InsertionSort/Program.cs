using System;
using System.Diagnostics;


namespace InsertionSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[4];
			array = GenerateDights(array);
				
			Stopwatch sw = Stopwatch.StartNew();
			sw.Start();

			InsertionSort(array);

			sw.Stop();

			Console.WriteLine($"Время работы {sw.ElapsedMilliseconds}");
		}

		public static int[] GenerateDights(int[] array)
		{
			var rand = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rand.Next(1,101);
			}
			return array;
		}

		public static int[] InsertionSort(int[] array)
		{
			for(int i = 1; i < array.Length; i++)
			{
				int k = array[i];
				int j = i - 1;

				// Пока j больше нуля и предыдущее число больше, чем последующее
				while(j >= 0 && array[j] > k)
				{
					//То мы вставляем на место последущего предыдущее, а предыдущее на место последующего
					array[j+1] = array[j];
					array[j] = k;
					j--;
				}
				// Если нет, не трогаем
			}
			return array;
		}

	}
}