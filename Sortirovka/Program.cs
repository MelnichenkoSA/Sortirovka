using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortirovka
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] masiv = UniqueRandomArray(-100, 100, 10);
            Bubble_Sort(masiv);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var a = UniqueRandomArray(-100, 100, 10);

            ArrayToString(a); 

            Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort(a)));

            Console.ReadLine();
        }

        public static void Bubble_Sort(int[] anArray)
        {
            //Выводим элементы массива (массив в исходном виде), исключительно диагностический вывод информации
            PrintArray(anArray);

            //Основной цикл (количество повторений равно количеству элементов массива)
            for (int i = 0; i < anArray.Length; i++)
            {
                //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                for (int j = 0; j < anArray.Length - 1 - i; j++)
                {
                    //Если элемент массива с индексом j больше следующего за ним элемента
                    if (anArray[j] > anArray[j + 1])
                    {
                        //Меняем местами элемент массива с индексом j и следующий за ним
                        Swap(ref anArray[j], ref anArray[j + 1]);
                    }
                }

                //Выводим элементы массива после очередной итерации, исключительно диагностический вывод информации
                PrintArray(anArray);
            }
        }

        //Вспомогательный метод, "меняет местами" два элемента
        public static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            //Временная (вспомогательная) переменная, хранит значение первого элемента
            int tmpParam = aFirstArg;

            //Первый аргумент получил значение второго
            aFirstArg = aSecondArg;

            //Второй аргумент, получил сохраненное ранее значение первого
            aSecondArg = tmpParam;
        }

        //Вспомогательный метод, выводящий на консоль элементы массива
        public static void PrintArray(int[] anArray)
        {
            //Перебор всех элементов массива
            for (int i = 0; i < anArray.Length; i++)
            {
                //Вывод значения текущего элемента и пробел после него
                Console.Write(anArray[i] + " ");
            }

            //Перевод строки
            Console.WriteLine("\n");
        }

        static bool ArrayContains(int[] numbers, int number)
        {
            foreach (var num in numbers) if (number == num) return true;
            return false;
        }
        static int[] UniqueRandomArray(int min, int max, int length, Random? random = null)
        {
            if (min >= max) throw new ArgumentException("Не верно задан диапазон: min >= max");
            if ((max - min) < length) throw new ArgumentException("Диапазон не позволяет создать уникальный список: (max - min) <= length");

            random = random ?? new Random(DateTime.Now.Millisecond);
            var result = new int[length];
            var zeroFirst = true;
            for (var i = 0; i < length; i++)
            {
                var res = 0;
                do
                {
                    res = random.Next(min, max);
                    if (res == 0)
                    {
                        if (zeroFirst)
                        {
                            zeroFirst = false;
                            break;
                        }
                        continue;
                    }
                } while (ArrayContains(result, res));
                result[i] = res;
            }
            return result;
        }
        static string ArrayToString(int[] numbers, bool show = true)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in numbers) sb.Append(item).Append(' ');
            var result = sb.ToString().TrimEnd(' ');
            if (show) Console.WriteLine(result);
            return result;
        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        
        
        //метод для обмена элементов массива


        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

     
    }
}
