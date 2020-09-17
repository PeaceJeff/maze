namespace MazeUtilities
{
    struct MazeCoords
    {
        public int x,y;
        public bool bStart,bFinish;
        public void aquireValues(int x, int y, bool start, bool finish)
        {
            this.x = x;
            this.y = y;
            this.bStart = start;
            this.bFinish = finish;
        }
        public static bool operator ==(MazeCoords m1, MazeCoords m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(MazeCoords m1, MazeCoords m2)
        {
            return !m1.Equals(m2);
        }
    }
}