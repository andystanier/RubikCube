namespace RubikCube
{
    public class Print : IDraw
    {
        public void Create(IEnumerable<Position>? positions)
        {
            if (positions != null && positions.Any())
            {
                foreach (Position position in positions)
                {
                    Colour xy = position.ColourMatrix.xyPlane;
                    Colour xz = position.ColourMatrix.xzPlane;
                    Colour yz = position.ColourMatrix.yzPlane;
                    Console.WriteLine($"{position?.Coordinates?.ToString()} - ({xy.ToAbbr()}, {xz.ToAbbr()}, {yz.ToAbbr()})");
                }
            }
        }
    }

}