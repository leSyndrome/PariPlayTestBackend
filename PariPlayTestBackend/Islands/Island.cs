using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PariPlayTestBackend.Matrix;

namespace PariPlayTestBackend.Islands
{
    public class Island
    {
        public int  Content { get; private set; }
        public int[,] Matrix { get; private set; }
        public  List<int> Cells { get; private set; } = new List<int>();


        public Island(int[,] matrix, int cellPosition)
        {
            Matrix = matrix;
            Content = matrix.Get(cellPosition);
            Cells.Add(cellPosition);
        }

        public void AddCell(int cellPosition)
        {
            if(!Matrix.IsInBounds(cellPosition))
                throw new ArgumentOutOfRangeException(nameof(cellPosition));
            Cells.Add(cellPosition);
        }
    }
}
