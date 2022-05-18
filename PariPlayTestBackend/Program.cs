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
                int[,] matrix = Matrix.ReadFromFile("matrix.txt");
                Matrix.PrintMatrix(matrix);
                Islands.PrintIslands(Islands.GetIslands(matrix), matrix);
                Console.WriteLine("-----------------------------------------------------------");
            }


            // Random Matrix from
            int n = Matrix.DEFAULT_SIZE;
            int m = Matrix.DEFAULT_SIZE;
            while (true)
            {
                GetInput(ref n, ref m);
                int[,] matrix = Matrix.GenerateRandom(n, m);
                Matrix.PrintMatrix(matrix);
                Islands.PrintIslands(Islands.GetIslands(matrix), matrix);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }

        static void GetInput(ref int n, ref int m)
        {
            Console.WriteLine("Enter matrix size");

            Console.Write("n: ");
            n = int.Parse(Console.ReadLine() ?? Matrix.DEFAULT_SIZE.ToString());
            if (n < Matrix.MIN_SIZE)
                n = Matrix.MIN_SIZE;
            if (n > Matrix.MAX_SIZE)
                n = Matrix.MAX_SIZE;

            Console.Write("m: ");
            m = int.Parse(Console.ReadLine() ?? Matrix.DEFAULT_SIZE.ToString());
            if (m < Matrix.MIN_SIZE)
                m = Matrix.MIN_SIZE;
            if (m > Matrix.MAX_SIZE)
                m = Matrix.MAX_SIZE;
        }


    }
}
