using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace PariPlayTestBackend.Matrix
{
    public static class Matrix
    {
        public const int DEFAULT_SIZE = 10;
        public const int MIN_SIZE = 6;
        public const int MAX_SIZE = 13;
        public const int MIN_VALUE = 0;
        public const int MAX_VALUE = 9;



        public static int[,] GenerateRandom(int n, int m)
        {
            ApplyBoundaries(ref n);
            ApplyBoundaries(ref m);

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

        public static int[,] ReadFromFile(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                int n = int.Parse(reader.ReadLine());
                int m = int.Parse(reader.ReadLine());
                ApplyBoundaries(ref n);
                ApplyBoundaries(ref m);

                int[,] matrix = new int[n, m];
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        matrix[i, j] = reader.Read() - '0';
                        int c = reader.Read();
                    }
                    reader.ReadLine();
                }

                return matrix;
            } 
        }

        public static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine(matrix.GetLength(0) + "x" + matrix.GetLength(1));

            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write("\t[" + j + "]");
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[" + i + "]");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("\t " + matrix[i, j]);
                }
                Console.WriteLine();
            }
        }



        public static int Get(this int[,] matrix, int position) => matrix[matrix.GetX(position), matrix.GetY(position)];
        public static int GetPosition(this int[,] matrix, int x, int y) => x * matrix.GetLength(0) + y;
        public static int GetX(this int[,] matrix, int position ) => position / matrix.GetLength(0);
        public static int GetY(this int[,] matrix, int position) => position % matrix.GetLength(0);
        public static int Left(this int[,] matrix, int position) => position - 1;
        public static int Right(this int[,] matrix, int position) => position + 1;
        public static int Top(this int[,] matrix, int position) => position - matrix.GetLength(0);
        public static int Bottom(this int[,] matrix, int position) => position + matrix.GetLength(0);
        public static bool IsInBounds(this int[,] matrix, int position) => position >= 0 && position <= matrix.Length;
        public static void ApplyBoundaries(ref int n) => n = n < MIN_SIZE ? MIN_SIZE : (n < MAX_SIZE ? n : MAX_SIZE);
    }
}
