using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива N: ");
        int N = int.Parse(Console.ReadLine());

        // создаем и заполняем массив
        double[] arr = new double[N];
        Random rand = new Random();
        for (var i = 0; i < N; i++)
        {
            arr[i] = rand.Next(-50, 50);
        }

        // выводим массив
        Console.WriteLine("Изначальный массив:");
        foreach (var element in arr)
        {
            Console.Write(element + " ");
        }

        Console.ReadLine();

        // 1) находим максимальный элемент массива
        double max = arr[0];
        for (int i = 1; i < N; i++)
            if (arr[i] > max)
                max = arr[i];
        Console.WriteLine("Максимальный элемент: " + max);

        // 2) вычисляем сумму элементов до последнего положительного элемента
        double sum = 0;
        for (int i = N - 1; i >= 0; i--)
        {
            if (arr[i] > 0)
                for (int j = 0; j < i; j++)
                    sum += arr[j];
            break;
        }
        Console.WriteLine("Сумма элементов до последнего положительного элемента: " + sum);

        // вводим интервал [а, b] для удаления элементов
        Console.WriteLine("Введите значение а: ");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите значение b: ");
        double b = double.Parse(Console.ReadLine());

        // удаляем элементы, модуль которых находится в интервале [а,b]
        int newSize = 0; // размер массива после сжатия
        for (int i = 0; i < N; i++)
        {
            if (Math.Abs(arr[i]) < a || Math.Abs(arr[i]) > b)
            {
                arr[newSize] = arr[i];
                newSize++;
            }
        }

        // заполняем оставшиеся элементы нулями
        for (int i = newSize; i < N; i++)
        {
            arr[i] = 0;
        }

        // выводим полученный массив
        Console.WriteLine("Измененный массив после удаления элементов:");
        foreach (var element in arr)
        {
            Console.Write(element + " ");
        }

        Console.ReadLine();

    Console.Write("Введите размерность матрицы: ");
        int N = int.Parse(Console.ReadLine());

        // создаем и заполняем матрицу
        int[,] matrix = new int[N, N];
        Random random = new Random();

        Console.WriteLine("Матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = random.Next(-10, 10); 
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // 1) сумма элементов в столбцах, не содержащих отрицательных элементов
        int sum = 0;
        for (int j = 0; j < N; j++)
        {
            bool containsNegative = false;
            for (int i = 0; i < N; i++)
            {
                if (matrix[i, j] < 0)
                {
                    containsNegative = true;
                    break;
                }
            }
            if (!containsNegative)
            {
                for (int i = 0; i < N; i++)
                {
                    sum += matrix[i, j];
                }
            }
        }

        Console.WriteLine("Сумма элементов в столбцах без отрицательных элементов: " + sum);

        // 2) минимум среди сумм модулей элементов диагоналей, параллельных побочной диагонали
        int minSum = int.MaxValue;
        var sum_arr = new int[2*N - 1];
        for (int i = 0; i < N; ++i)
        { 
            for (int j = 0; j < N; ++j)
            { 
                sum_arr[i + j] += Math.Abs(matrix[i, j]);
            }
        }
        foreach (int sums in sum_arr)
        {
            minSum = Math.Min(minSum, sums);
        }
        Console.WriteLine("Минимум среди сумм модулей элементов диагоналей, параллельных побочной диагонали: " + minSum);
        Console.ReadLine();
    }
}
