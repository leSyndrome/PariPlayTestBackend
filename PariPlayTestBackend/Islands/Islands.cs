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
            List<WildcardIsland> wildcardIslands = new List<WildcardIsland>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int currCell = matrix.GetPosition(i, j);

                    if (WildcardIsland.CellIsWildcard(i, j, matrix) && !islandMap.ContainsKey(currCell))
                    {
                        WildcardIsland wildCardIsland = new WildcardIsland(matrix, currCell);
                        wildcardIslands.Add(wildCardIsland);
                        islandMap.Add(currCell, wildCardIsland);
                        foreach(int cell in islandMap[currCell].Cells)
                            islandMap[cell] = islandMap[currCell];
                    }
                    else
                    {
                        if (j < matrix.GetLength(1) - 1)
                            if (matrix[i, j] == matrix[i, j + 1])
                                ProcessPair(currCell, currCell.Right(matrix), matrix, islandMap);

                        if (i < matrix.GetLength(0) - 1)
                            if (matrix[i, j] == matrix[i + 1, j])
                                ProcessPair(currCell, currCell.Bottom(matrix), matrix, islandMap);
                    }
                }
            }


            foreach (WildcardIsland wildCardIsland in wildcardIslands)
                wildCardIsland.ApplyWildcard(islandMap);
            
            return islandMap.Values.Distinct().Where(island => island.Cells.Count >= MIN_ISLAND_SIZE).ToList();
        }


        public static void ProcessPair(int cellPosition, int otherCellPosition, int[,] matrix, Dictionary<int, Island> islandMap)
        {
            if (!islandMap.ContainsKey(cellPosition))
                islandMap[cellPosition] = new Island(matrix, cellPosition);
            islandMap[cellPosition].AddCell(otherCellPosition);
            islandMap[otherCellPosition] = islandMap[cellPosition];
        }


        public static void PrintIslands(List<Island> islands, int[,] matrix)
        {
            int islandCounter = 1;
            foreach (Island island in islands)
            {
                Console.WriteLine("Island " + islandCounter + "\t" + island);
                islandCounter++;
            }
        }

    }
}



