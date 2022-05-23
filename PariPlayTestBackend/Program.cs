using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariPlayTestBackend
{
    public class Program
    {
        static void Main()
        {
            // File
            {
                Console.WriteLine("Matrix loaded from file: ");
                int[,] matrix = Matrix.Matrix.ReadFromFile("matrix.txt");
                Matrix.Matrix.PrintMatrix(matrix);
                Islands.Islands.PrintIslands(Islands.Islands.GetIslands(matrix), matrix);
                Console.WriteLine("-----------------------------------------------------------");
            }


            // Random Matrix from input size
            int n = Matrix.Matrix.DEFAULT_SIZE;
            int m = Matrix.Matrix.DEFAULT_SIZE;
            while (true)
            {
                GetInput(ref n, ref m);
                int[,] matrix = Matrix.Matrix.GenerateRandom(n, m);
                Matrix.Matrix.PrintMatrix(matrix);
                Islands.Islands.PrintIslands(Islands.Islands.GetIslands(matrix), matrix);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }

        static void GetInput(ref int n, ref int m)
        {
            Console.WriteLine("Enter matrix size");
            Console.Write("n: ");
            n = int.Parse(Console.ReadLine() ?? Matrix.Matrix.DEFAULT_SIZE.ToString());
            Console.Write("m: ");
            m = int.Parse(Console.ReadLine() ?? Matrix.Matrix.DEFAULT_SIZE.ToString());
        }


    }
}
