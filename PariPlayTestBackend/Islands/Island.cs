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
            AddCell(cellPosition);
        }

        public virtual void AddCell(int cellPosition)
        {
            if(!cellPosition.IsInBounds(Matrix))
                throw new ArgumentOutOfRangeException(nameof(cellPosition));
            if(!Cells.Contains(cellPosition))
                Cells.Add(cellPosition);
        }

        public void Join(Island other)
        {
            if(Content != other.Content || Matrix != other.Matrix)
                throw new ArgumentException(nameof(other));
            Cells.Concat(other.Cells);
            other = this;
        }

        public override string ToString()
        {
            string result = "Content: " + Content + "\tSize:  " + Cells.Count +  "\tCells: ";
            foreach (int i in Cells)
                result += " " + i;
            return result;
        }
    }
}
