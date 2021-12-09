namespace Days
{
    public class HeightMap
    {
        public HeightMap()
        {
            Locations = new List<Location>();
        }
        public List<Location> Locations { get; set; }

        public List<Location> GetAdjacentLocations(Location location)
        {
            return Locations.Where(x => (x.X == location.X && x.Y == location.Y + 1) || 
                                        (x.X == location.X && x.Y == location.Y - 1) || 
                                        (x.Y == location.Y && x.X == location.X + 1) || 
                                        (x.Y == location.Y && x.X == location.X - 1))
                            .ToList();
        }

        public void Print()
        {
            for (int y = 0; y <= Locations.Max(x => x.Y); y++)
            {
                Console.WriteLine();
                for (int x = 0; x <= Locations.Max(x => x.X); x++)
                {
                    var height = Locations.Single(z => z.Y == y && z.X == x).Height;
                    if (height == 9)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(height);
                    Console.ResetColor();
                }
            }
        }
    }
}
