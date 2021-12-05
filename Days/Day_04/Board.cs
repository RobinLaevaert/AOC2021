namespace Days
{
    public class Board
    {
        public List<Field> Fields { get; set; }
        public List<List<Field>> Rows => Fields.GroupBy(x => x.Y).Select(x => x.ToList()).ToList();
        public List<List<Field>> Columns => Fields.GroupBy(x => x.X).Select(x => x.ToList()).ToList();
        public bool hasBingo => Rows.Any(x => x.All(y => y.Checked)) || Columns.Any(x => x.All(y => y.Checked));

        public void PlayNumber(int value)
        {
            var fieldsToCheck = Fields.Where(x => x.Value == value).ToList();
            foreach (var field in fieldsToCheck)
            {
                field.Check();
            }
        }

        public Board(List<string> input)
        {
            Fields = new List<Field>();
            for (int i = 0; i < input.Count; i++)
            {
                var split = input[i].Split(' ').Where(x => x != String.Empty).ToList();
                var fieldsToAdd = split.Select((x, index) => new Field(index, i, Convert.ToInt32(x)));
                Fields.AddRange(fieldsToAdd);
            }
        }

        public void printBoard()
        {
            foreach (var row in Rows)
            {
                Console.WriteLine();
                foreach (var number in row)
                {
                    if (number.Checked)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(number.Value.ToString().PadLeft(2));
                    Console.Write(' ');
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
