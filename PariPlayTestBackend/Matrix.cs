using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariPlayTestBackend
{
    public static class Matrix
    {
        public const int DEFAULT_SIZE = 6;
        public const int MIN_SIZE = 6;
        public const int MAX_SIZE = 13;
        public const int MIN_VALUE = 0;
        public const int MAX_VALUE = 9;


        public static int[,] GenerateRandom(int n, int m)
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

        public static void PrintMatrix(int[,] matrix)
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
