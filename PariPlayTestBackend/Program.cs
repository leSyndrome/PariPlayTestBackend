using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariPlayTestBackend
{
    public class Program
    {
        const int DEFAULT_SIZE = 6;
        const int MIN_SIZE = 6;
        const int MAX_SIZE = 13;
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 9;


        static void Main()
        {
            int n = DEFAULT_SIZE;
            int m = DEFAULT_SIZE;

            while (true)
            {
                GetInput(ref n, ref m);
                int[,] matrix = GetRandomMatrix(n, m);
                PrintMatrix(matrix);
                Islands.PrintIslands(Islands.GetIslands(matrix), matrix);
            }
        }

        static void GetInput(ref int n, ref int m)
        {
            Console.WriteLine("Enter matrix size");

            Console.Write("n: ");
            n = int.Parse(Console.ReadLine() ?? DEFAULT_SIZE.ToString());
            if (n < MIN_SIZE)
                n = MIN_SIZE;
            if (n > MAX_SIZE)
                n = MAX_SIZE;

            Console.Write("m: ");
            m = int.Parse(Console.ReadLine() ?? DEFAULT_SIZE.ToString());
            if (m < MIN_SIZE)
                m = MIN_SIZE;
            if (m > MAX_SIZE)
                m = MAX_SIZE;
        }

        static int[,] GetRandomMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(MIN_VALUE, MAX_VALUE);
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine(matrix.GetLength(0) + "x" + matrix.GetLength(1));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
