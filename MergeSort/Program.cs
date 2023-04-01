using System;
using System.Diagnostics;


namespace MergeSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[5];
			GenerateDights(array);

			Stopwatch sw = Stopwatch.StartNew();

			sw.Start();
			MergeSort(array);
			sw.Stop();

			Console.WriteLine($"Время работы {sw.ElapsedMilliseconds}");
		}
		public static int[] GenerateDights(int[] array)
		{
			var rand = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rand.Next(1, 101);
			}
			return array;
		}
		static void MergeSort(int[] array)
		{
			if(array.Length == 1)
			{
				return;
			}
			// Разделение массива на две части 

			int mid = array.Length / 2;
			int[] left = new int[mid];
			int[] right = new int[array.Length - mid];

			// Присваивание элементов левой и правой частями
			for(int i = 0; i < mid; i++)
			{
				left[i] = array[i];
			}

			for(int i = mid; i < array.Length; i++)
			{
				right[i - mid] = array[i];
			}

            // Рекурсия, деление массива на части
            MergeSort(left);			
			MergeSort(right);

			// Слияние в отсортированный подмассив
			Merge(array,left,right);
		}
	
		public static void Merge(int[] targetArray, int[] array1, int[] array2)
		{
			int array1MinIndex = 0;
			int array2MinIndex = 0;

			int targetArrayMinIndex = 0;

			while(array1MinIndex < array1.Length && array2MinIndex < array2.Length)
			{
				if (array1[array1MinIndex] <= array2[array2MinIndex])
				{
					targetArray[targetArrayMinIndex] = array1[array1MinIndex];
					array1MinIndex++;
				}
				else
				{
					targetArray[targetArrayMinIndex] = array2[array2MinIndex];
					array2MinIndex++;
				}
				targetArrayMinIndex++;
			}
			while(array1MinIndex < array1.Length)
			{
				targetArray[targetArrayMinIndex] = array1[array1MinIndex];
				array1MinIndex++;
				targetArrayMinIndex++;
			}
			while(array2MinIndex < array2.Length)
			{
				targetArray[targetArrayMinIndex] = array2[array2MinIndex];
				array2MinIndex++;
				targetArrayMinIndex++;
			}
		}
		public static void DisplayArray(int[] array)
		{
			var s = string.Join(" ", array);
			Console.WriteLine(s);
		}
		
	}
}