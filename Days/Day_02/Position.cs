namespace Days
{
    public class Position
    {
        public Position(int horizontalPos, int depth)
        {
            HorizontalPosition = horizontalPos;
            Depth = depth;
        }

        public int HorizontalPosition {  get; set; } 
        public int Depth {  get; set; }
    }
}
