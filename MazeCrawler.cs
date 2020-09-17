using MazeUtilities;
using mazeConstructor;
using System.Collections.Generic;
using System.Runtime.InteropServices;
class MazeCrawler
{
    public MazeCoords crawlerPos;
    private RPAMaze mazeMap;
    public MazeCrawler(MazeCoords inputStartPosition, RPAMaze inputMaze)
    {
        this.crawlerPos = inputStartPosition;
        this.mazeMap = inputMaze;
    }

    public List<MazeCoords> findPath2Finish(List<MazeCoords> path, MazeCoords move2Coords)
    {
        //I understand that this might look stupid to duplicate variable but I am keeping meaningful naming and optimizing text in operations.
        //Due to my in experience in C# these are little points I would like to discuss with Tech lead.
        MazeCoords m2C = move2Coords;
        //adding coordinates to list of path to track movement of the crawler.
        //checking if crawler reaches any of the edge of the Maze. Maze Edge -> Finish. Start Position cannot be the exit
        if (mazeMap.maze2DArray[m2C.x][m2C.y] != 2) 
        {
            m2C.bStart = false;
        }else
        {
            m2C.bStart = true;
        }
        if (m2C.bStart!= true && (m2C.x == 0 || m2C.x == mazeMap.Height-1 || m2C.y == 0 || m2C.y == mazeMap.Width-1)) m2C.bFinish = true;
        if (m2C.bFinish)
        {
            path.Add(m2C);
            return(path);
        }else
        {// this huge part is undoubtably can be optimized and put in a separate meaningful methods.
            path.Add(m2C);
            
            //go North
            var potNPos = m2C;
            potNPos.x--;
            if(m2C.x != 0)
            {
                if(mazeMap.maze2DArray[m2C.x-1][m2C.y] != 1 && checkPathHistory(path,potNPos))
                {
                    System.Console.WriteLine("Top: x:{0}, y:{1}",potNPos.x,potNPos.y);
                    path = findPath2Finish(path, potNPos);
                }
            }
            if (path[path.Count-1].bFinish)return(path);

            //go East
            var potEPos = m2C;
            potEPos.y++;
            if(m2C.y != mazeMap.Width-1)
            {
                if(mazeMap.maze2DArray[m2C.x][m2C.y+1] != 1 && checkPathHistory(path,potEPos))
                {
                    System.Console.WriteLine("Right: x:{0}, y:{1}",potEPos.x,potEPos.y);
                    path = findPath2Finish(path, potEPos);
                }
            }
            if (path[path.Count-1].bFinish)return(path);

            //go South
            var potSPos = m2C;
            potSPos.x++;
            if(m2C.x != mazeMap.Height-1)
            {
                if(mazeMap.maze2DArray[m2C.x+1][m2C.y] != 1 && checkPathHistory(path,potSPos))
                {
                    System.Console.WriteLine("Bottom: x:{0}, y:{1}",potSPos.x,potSPos.y);
                    path = findPath2Finish(path, potSPos);
                }
            }
            if (path[path.Count-1].bFinish)return(path);

            //go West
            var potWPos = m2C;
            potWPos.y--;
            if(m2C.y != 0)
            {
                if(mazeMap.maze2DArray[m2C.x][m2C.y-1] != 1 && checkPathHistory(path,potWPos))
                {
                    System.Console.WriteLine("Left: x:{0}, y:{1}",potWPos.x,potWPos.y);
                    path = findPath2Finish(path, potWPos);
                }
            }
            //When finish is reached return path to the finish.
            if (path[path.Count-1].bFinish)return(path);
           
            //Return one cell back
            path.RemoveAt(path.Count-1);
            System.Console.WriteLine("Back: x:{0}, y:{1}",m2C.x,m2C.y);
            return(path);
        }
        
    }

    private bool checkPathHistory(List<MazeCoords> cPath, MazeCoords crwlCoords)
    {
        if (mazeMap.maze2DArray[crwlCoords.x][crwlCoords.y] != 2) 
        {
            crwlCoords.bStart = false;
        }else
        {
            crwlCoords.bStart = true;
        }
        foreach (MazeCoords path in cPath)
        {
            if (path == crwlCoords)
            {
                return(false);
            }
        }
        return(true);
    }
}