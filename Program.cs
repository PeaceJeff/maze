using MazeFileIO;
using mazeConstructor;
using MazeUtilities;
using System.Collections.Generic;
using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var rMF = new MazeFile("RPAMaze.txt");
            RPAMaze oMaze = new RPAMaze(rMF.extractHeight(), rMF.extractWidth());
            
            rMF.printMaze2Console();
            string[] mMatrix = rMF.getMatrixStringLines();
            oMaze.initializeMaze(mMatrix);
            int numberOfArguments = args.Length;
            
            MazeCoords mazeStartCoords;
            if(numberOfArguments == 2)
            {
                mazeStartCoords = new MazeCoords();
                mazeStartCoords.aquireValues (Int32.Parse(args[0]), Int32.Parse(args[1]), true, false);    
            }else
            {
                System.Console.WriteLine("Incorrect ammount or no Arguments passed.");
                mazeStartCoords = oMaze.getMazeStart();
            }
            
            MazeCrawler nervousJeff = new MazeCrawler(mazeStartCoords, oMaze);
            List<MazeCoords> path2Victory = new List<MazeCoords>();
            path2Victory = nervousJeff.findPath2Finish(path2Victory, mazeStartCoords);
            if (path2Victory.Count==0)System.Console.WriteLine("I am trapped in this \"MAZE\". Why did you trap me in here?");
            rMF.logMazeSolution(path2Victory);
        }
    }
}