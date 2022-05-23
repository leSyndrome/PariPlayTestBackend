using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PariPlayTestBackend.Matrix;

namespace PariPlayTestBackend.Islands
{
    public class WildcardIsland : Island
    {
        public List<int> NeighborCells { get; set; } = new List<int>();
        public WildcardIsland(int[,] matrix, int cellPosition) : base(matrix, cellPosition) { }


        public override void AddCell(int cellPosition)
        {
            if (!Cells.Contains(cellPosition))
            {
                base.AddCell(cellPosition);
                AddNeighbourCells(cellPosition);
            }
        }
        
        
        public void ApplyWildcard(Dictionary<int, Island> islandMap)
        {
            Island currentIsland;
            foreach(int cellPosition in NeighborCells)
            {
                if(islandMap.ContainsKey(cellPosition))
                    currentIsland = islandMap[cellPosition];
                else
                    currentIsland = new Island(Matrix, cellPosition);
            

                foreach(int neighborCell in NeighborCells)
                {
                    if(Matrix.Get(neighborCell) == currentIsland.Content)
                    {
                        if(islandMap.ContainsKey(neighborCell))
                            currentIsland.Join(islandMap[neighborCell]);
                        else
                        {
                            currentIsland.AddCell(neighborCell);
                            islandMap[neighborCell] = currentIsland;
                        }
                    }
                }

                foreach (int wildcardCell in Cells)
                    currentIsland.AddCell(wildcardCell);

                Matrix.Get(cellPosition);
            }
        }
        public void AddNeighbourCells(int cellPosition)
        {
            AddNeighbourCell(cellPosition.Top(Matrix)); 
            AddNeighbourCell(cellPosition.Left(Matrix)); 
            AddNeighbourCell(cellPosition.Bottom(Matrix)); 
            AddNeighbourCell(cellPosition.Right(Matrix)); 
        }
        private void AddNeighbourCell(int cellPosition)
        {
            if (cellPosition.IsInBounds(Matrix))
            {
                if(CellIsWildcard(cellPosition, Matrix))
                {
                    AddCell(cellPosition);
                }
                else if (!NeighborCells.Contains(cellPosition))
                {
                    NeighborCells.Add(cellPosition);
                }
            }
        }


        public static bool CellIsWildcard(int cellPosition, int[,] matrix) => matrix.Get(cellPosition) == 0;
        public static bool CellIsWildcard(int x, int y, int[,] matrix) => matrix[x, y] == 0;

    }
}
