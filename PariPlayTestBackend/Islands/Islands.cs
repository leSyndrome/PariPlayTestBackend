using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PariPlayTestBackend.Matrix;


namespace PariPlayTestBackend.Islands
{
    public static class Islands
    {
        const int MIN_ISLAND_SIZE = 4;


        public static List<Island> GetIslands(int[,] matrix)
        {
            Dictionary<int, Island> islandMap = new Dictionary<int, Island>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int currCel = matrix.GetPosition(i, j);

                    //if (matrix[i, j] == 0)
                    //    ProcessWildCard(currPosition, matrix, islandMap);

                    if (j < matrix.GetLength(1) - 1)
                        if (matrix[i, j] == matrix[i, j + 1])
                            ProcessPair(currCel, matrix.Right(currCel), matrix, islandMap);

                    if (i < matrix.GetLength(0) - 1)
                        if (matrix[i, j] == matrix[i + 1, j])
                            ProcessPair(currCel, matrix.Bottom(currCel), matrix, islandMap);
                }
            }
            
            return islandMap.Values.Distinct().Where(island => island.Cells.Count >= MIN_ISLAND_SIZE).ToList();
        }


        public static void ProcessPair(int cellPosition, int otherCellPosition, int[,] matrix, Dictionary<int, Island> islandMap)
        {
            if (!islandMap.ContainsKey(cellPosition))
                islandMap[cellPosition] = new Island(matrix, cellPosition);
            islandMap[cellPosition].AddCell(otherCellPosition);
            islandMap[otherCellPosition] = islandMap[cellPosition];
        }

        //public static void ProcessWildCard(int wildcardPosition,
        //                                    int[,] matrix,
        //                                    Dictionary<int, Island> islandMap)
        //{
        //    if (neighbourIslands == null)
        //        neighbourIslands = new Dictionary<int, List<int>>();

        //    List<int> neighbourPositions = new List<int>()
        //    {
        //         wildcardPosition.Top(matrix),
        //         wildcardPosition.Left(matrix)
        //    };


        //    foreach (int neighbourPosition in neighbourPositions)
        //    {
        //        if (neighbourPosition.IsInBounds(matrix))
        //        {
        //            int value = matrix.Get(neighbourPosition);
        //            if (value != 0)
        //            {
        //                if (neighbourIslands.ContainsKey(value))
        //                {
        //                    if (islandMap.ContainsKey(neighbourPosition) && neighbourIslands[value] != islandMap[neighbourPosition])
        //                    {
        //                        neighbourIslands[value].Concat(islandMap[neighbourPosition]);
        //                        islandMap[neighbourPosition] = neighbourIslands[value];
        //                    }
        //                    else
        //                    {
        //                        neighbourIslands[value].Add(value);
        //                    }
        //                }
        //                else
        //                {
        //                    if (islandMap.ContainsKey(neighbourPosition))
        //                    {
        //                        neighbourIslands[value] = islandMap[neighbourPosition];
        //                    }
        //                    else
        //                    {
        //                        islandMap[neighbourPosition] = new List<int> { neighbourPosition };
        //                        neighbourIslands[value] = islandMap[neighbourPosition];
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ProcessWildCard(neighbourPosition, matrix, islandMap, neighbourIslands);
        //            }
        //        }
        //    }
        //    foreach (var island in neighbourIslands.Values)
        //    {
        //        island.Add(wildcardPosition);
        //    }


        //}


        public static void PrintIslands(List<Island> islands, int[,] matrix)
        {
            int islandCounter = 1;
            foreach (Island island in islands)
            {
                Console.WriteLine();
                Console.Write("Island " + islandCounter + "\tSize:  " + island.Cells.Count + "\tContent: " + island.Content + "\tOn positions:");
                foreach (int i in island.Cells)
                    Console.Write(" " + i);
                Console.WriteLine();
                islandCounter++;
            }
        }

    }
}



