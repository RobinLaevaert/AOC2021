using Shared;

namespace Days
{
    public class Day_05 : Day
    {
        List<Line> Lines;
        public Day_05()
        {
            Title = "Hydrothermal Venture";
            DayNumber = 5;
        }
        public override void Gather_input()
        {
            Lines = Read_file()
                        .Select(x => x.Split(" -> "))
                        .Select(x =>
                            {
                                var from = x[0].Split(',').Select(x => Convert.ToInt32(x)).ToList();
                                var to = x[1].Split(',').Select(x => Convert.ToInt32(x)).ToList();
                                return new Line(from[0], from[1], to[0], to[1]);
                            }
                        ).ToList();
        }

        protected override string HandlePart1()
        {
            var linesToConsider = Lines.Where(x => x.fromY == x.toY || x.fromX == x.toX).ToList();
            var visitedPoints = GetVisitedPoints(linesToConsider);
            return visitedPoints.GroupBy(x => new {x.x, x.y}).Where(x => x.Count() > 1).Count().ToString();
        }

        protected override string HandlePart2()
        {
            var visitedPoints = GetVisitedPoints(Lines);
            return visitedPoints.GroupBy(x => new { x.x, x.y }).Where(x => x.Count() > 1).Count().ToString();
        }

        public List<VisitedPoint> GetVisitedPoints(List<Line> lines)
        {
            var visitedPoints = new List<VisitedPoint>();
            foreach (var line in lines)
            {
                var minX = Math.Min(line.fromX, line.toX);
                var maxX = Math.Max(line.fromX, line.toX);
                var minY = Math.Min(line.fromY, line.toY);
                var maxY = Math.Max(line.fromY, line.toY);
                var rangeX = Enumerable.Range(minX, maxX - minX + 1);
                var rangeY = Enumerable.Range(minY, maxY - minY + 1);
                var correctOrderX = line.fromX < line.toX ? rangeX.ToList() : rangeX.Reverse().ToList();
                var correctOrderY = line.fromY < line.toY ? rangeY.ToList() : rangeY.Reverse().ToList();
                var pointsToAdd = correctOrderX.Count() == correctOrderY.Count() ?
                                        correctOrderX.Select((x, index) => new VisitedPoint(x, correctOrderY[index])) :
                                        correctOrderY.Count() == 1 ? 
                                            correctOrderX.Select(x => new VisitedPoint(x, correctOrderY.Single())) :
                                            correctOrderY.Select(y => new VisitedPoint(correctOrderX.Single(), y));
                visitedPoints.AddRange(pointsToAdd);
            }
            return visitedPoints;
        }
    }


    public record Line (int fromX, int fromY, int toX, int toY);
    public record VisitedPoint(int x, int y);
}
