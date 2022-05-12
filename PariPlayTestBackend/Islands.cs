using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Islands
{
    const int MIN_ISLAND_SIZE = 4;


    public static List<List<int>> GetIslands(int[,] matrix)
    {
        List<int> wildcardPositions = new List<int>();
        Dictionary<int, List<int>> islandMap = new Dictionary<int, List<int>>();


        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int index = GetIndex(i, j, matrix);

                //Check and save wildcards
                if (matrix[i, j] == 0)
                {
                    wildcardPositions.Add(index);
                    continue;
                }

                if(j < matrix.GetLength(1) - 1)
                {
                    int rightIndex = index + 1;
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        if (!islandMap.ContainsKey(index))
                            islandMap[index] = new List<int>() { index };
                        islandMap[index].Add(rightIndex);
                        islandMap[rightIndex] = islandMap[index];
                    }
                }

                if (i < matrix.GetLength(0) - 1)
                {
                    int bottomIndex = GetIndex(i + 1, j, matrix);
                    if (matrix[i, j] == matrix[i + 1, j])
                    {
                        if (!islandMap.ContainsKey(index))
                            islandMap[index] = new List<int>() { index };
                        islandMap[index].Add(bottomIndex);
                        islandMap[bottomIndex] = islandMap[index];
                    }
                }
            }
        }

        foreach (int wildcardPosition in wildcardPositions)
            ProcessWildCard(matrix, wildcardPosition, islandMap);

        return islandMap.Values.Distinct().Where(island => island.Count >= MIN_ISLAND_SIZE).ToList();
    }


    public static void ProcessWildCard(int[,] matrix, int wildcardPosition, Dictionary<int, List<int>> islandMap)
    {
        int leftPosition = wildcardPosition - 1;
        int rightPosition = wildcardPosition + 1;
        int topPosition = wildcardPosition - matrix.GetLength(0);
        int bottomPosition = wildcardPosition + matrix.GetLength(0);

        //Left
        if (islandMap.ContainsKey(leftPosition))
            islandMap[leftPosition].Add(wildcardPosition);
        //Right
        if(islandMap.ContainsKey(rightPosition) && !islandMap[rightPosition].Contains(wildcardPosition))
            islandMap[rightPosition].Add(wildcardPosition);
        //Top
        if(islandMap.ContainsKey(topPosition) && !islandMap[topPosition].Contains(wildcardPosition))
            islandMap[topPosition].Add(wildcardPosition);
        //Bottom
        if(islandMap.ContainsKey(bottomPosition) && !islandMap[bottomPosition].Contains(wildcardPosition))
            islandMap[bottomPosition].Add(wildcardPosition);
    }


    public static void PrintIslands(List<List<int>> islands, int[,] matrix)
    {
        int islandCounter = 1;
        foreach (List<int> island in islands)
        {
            Console.WriteLine();
            Console.Write("Island " + islandCounter + "\tSize:  " + island.Count + "\tId: " + GetIslandId(island, matrix) + "\tOn positions:");
            foreach (int i in island)
                Console.Write(" " + i);
            Console.WriteLine();
            islandCounter++;
        }
    }

    static int GetIndex(int i, int j, int[,] matrix) => i * matrix.GetLength(0) + j;
    static int GetValueByIndex(int[,] matrix, int index) => matrix[GetRowByIndex(matrix, index), GetRowPositionByIndex(matrix, index)];
    static int GetRowByIndex(int[,] matrix, int index) =>  index / matrix.GetLength(0);    
    static int GetRowPositionByIndex(int[,] matrix, int index) =>  index % matrix.GetLength(0);
    static int GetIslandId(List<int> island, int[,] matrix) {
        foreach (int i in island)
        {
            int id = GetValueByIndex(matrix, i);
            if (id != 0)
                return id;
        }
        return 0;
    }

}



