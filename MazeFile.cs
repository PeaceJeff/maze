using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using MazeUtilities;

namespace MazeFileIO
{
    class MazeFile
    {
        private string [] lines;
        public MazeFile(string filename)
        {
            string localPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string TxtFilePath = Path.Combine(localPath, filename);
            lines = File.ReadAllLines(TxtFilePath);
        }

        public void printMaze2Console()
        {
            var skippedLines = lines.Skip(1);
            //since there is a requirement to print the maze in the begging.
            //I decided to cheat a bit in order to not iterate on matrix.
            foreach(var line in skippedLines)
            {
                System.Console.WriteLine(line);
            }
        }
        public int extractWidth()
        {
            string[] coords = lines[0].Split(" ");
            return(Int32.Parse(coords[1]));
        }
        public int extractHeight()
        {
            string[] coords = lines[0].Split(" ");
            return(Int32.Parse(coords[0]));
        }

        public string[] getMatrixStringLines()
        {
            return(lines.Skip(1).ToArray());

        }
        public void logMazeSolution(List<MazeCoords> pathToVictory)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine("=====================");
                w.WriteLine("Solution started: {0}",DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                w.WriteLine("=====================");
                if (pathToVictory.Count==0)w.WriteLine("There was no possible solution.");
                foreach(var coord in pathToVictory)
                {
                    w.WriteLine("x:{0},y:{1}",coord.x,coord.y);
                }
            }
        }
    }
}