namespace Days
{
    public class Field
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public bool Checked { get; set; }
        public void Check()
        {
            Checked = true;
        }

        public Field(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
            Checked = false;
        }
    }
}
