namespace Days
{
    public static class Day_10Extensions
    {
        public static char GetClosingChar(this char input)
        {
            if (input == '[') return ']';
            if (input == '<') return '>';
            if (input == '{') return '}';
            if (input == '(') return ')';
            throw new NotImplementedException();
        }

        public static int GetPoints(this char input)
        {
            return input switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => throw new NotImplementedException()
            };
        }
        public static int GetPointsP2(this char input)
        {
            return input switch
            {
                ')' => 1,
                ']' => 2,
                '}' => 3,
                '>' => 4,
                _ => throw new NotImplementedException()
            };
        }
    }
}
