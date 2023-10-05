using System;

class Program
{
    static void Main()
    {
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
