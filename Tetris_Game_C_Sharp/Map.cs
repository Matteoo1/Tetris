using System.ComponentModel;

namespace Tetris
{
	public class Map
	{ 
		private readonly int[,] map;
		public int Rows { get; }
		public int Columns { get; }

		public int this[int rows, int columns]
		{

			get=> map[rows, columns];
			set => map[rows, columns] = value;
        }


	public Map(int r, int c)
		{
            Rows = r;
			Columns = c;
			map = new int[r , c];
        }

        public bool CheckIfIn(int rows, int columns)
        {
            bool withinRowBounds = rows >= 0 && rows < Rows;
            bool withinColumnBounds = columns >= 0 && columns < Columns;
            return withinRowBounds && withinColumnBounds;
        }


        public bool EmptyMap(int row, int columns)
        {
            if (CheckIfIn(row, columns))
                return map[row, columns] == 0;

            else
                return false;
        }

        public bool CheckFullRow(int row)
        {
            for(int i = 0; i < Columns; i++)
            {
                if (map[row,i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEmptyRow(int row)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (map[row, i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int row)
        {
            for (int i=0; i < Columns; i++)
            {
                map[row, i] = 0;
            }
        }

        private void DropRow(int row, int numberOfRows)
        {
            for (int i = 0; i < Columns; i++)
            {
                map[row + numberOfRows, i] = map[row, i];
                map[row, i] = 0;
            }
        }
        
        public int EmptyFinishedRows()
        {
            int clear = 0;
            for (int row = Rows-1; row >= 0; row--)
            {
                if (CheckFullRow(row))
                {
                    ClearRow(row);
                    clear ++;
                }
                else if (clear > 0)
                {
                    DropRow(row, clear);
                }
            }
            return clear;
        }
    }
    
    // test

}