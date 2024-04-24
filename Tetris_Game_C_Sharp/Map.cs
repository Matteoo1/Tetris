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

//test
        public bool CheckIfIn(int rows, int columns)
        {
            bool withinRowBounds = rows >= 0 && rows < Rows;
            bool withinColumnBounds = columns >= 0 && columns < Columns;

            return withinRowBounds && withinColumnBounds;
        }


        public bool EmptyMap(int rows, int columns)
        {


            if (CheckIfIn(rows, columns))
                return map[rows, columns] == 0;

            else
                return false;
        }

        public bool FullRow(int rows)
        {
            for(int i = 0; i < Columns; i++)
            {
                if (map[rows,i] == 0)
                {
                    return false;
                }
            }
            return true;

        }

        public bool EmptyRows(int rows)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (map[rows, i] != 0)
                {
                    return false;
                }
            }
            return true;

        }


    }


}