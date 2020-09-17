using System;
using MazeUtilities;

namespace mazeConstructor
{
    class RPAMaze
    {
        public int Width, Height;
        public int[][] maze2DArray;

        public RPAMaze(int mHeight, int mWidth)
        {
            this.Height = mHeight;
            this.Width = mWidth;
            this.maze2DArray = new int[this.Height][];
        }

        public void initializeMaze(string [] matrixLines)
        {            
            //put every line of string into matrix of 2 dimensions
            int i = 0;
            foreach (string line in matrixLines)
            {
                maze2DArray[i] = Array.ConvertAll (line.Split(" "), int.Parse);
                i++;
            }
        }

        public MazeCoords getMazeStart ()
        {
            MazeCoords mazeCoords = new MazeCoords ();
            for (int indx = 0; indx <= this.Height-1; indx++)
            {
                for (int indy = 0; indy <= this.Width-1; indy++)
                {
                    if (maze2DArray[indx][indy] == 2)
                    {
                        mazeCoords.aquireValues (indx,indy,true,false);
                        break;
                    }
                }
                if (mazeCoords.bStart) break;
            }
            return (mazeCoords);
        }
    }
}