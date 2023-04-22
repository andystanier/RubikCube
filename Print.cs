using System.Text;

namespace RubikCube
{
    public class Print : IDraw
    {
        private Position _position;
        public void Create(IEnumerable<Position>? positions)
        {
            if (positions != null && positions.Any())
            {
                foreach (Position position in positions)
                {
                    Colour xy = position.ColourMatrix.xyPlane;
                    Colour xz = position.ColourMatrix.xzPlane;
                    Colour yz = position.ColourMatrix.yzPlane;
                    //Console.WriteLine($"{position?.Coordinates?.ToString()} - ({xy.ToAbbr()}, {xz.ToAbbr()}, {yz.ToAbbr()})");
                }
                CreateLayout(positions);
            }
        }

        private void CreateLayout(IEnumerable<Position>? positions)
        {

            // To print in a 2D representation of the Cube.
            StringBuilder sb = BuildTheArray(positions);
            System.Console.WriteLine(sb.ToString());
        }

        public int[] GetBlankSquares()
        {

            int[] blanksRow1 = { 101, 102, 103, 107, 108, 109, 110, 111, 112 };
            int[] blanksRow2 = { 201, 202, 203, 207, 208, 209, 210, 211, 212 };
            int[] blanksRow3 = { 301, 302, 303, 307, 308, 309, 310, 311, 312 };
            int[] blanksRow7 = { 701, 702, 703, 707, 708, 709, 710, 711, 712 };
            int[] blanksRow8 = { 801, 802, 803, 807, 808, 809, 810, 811, 812 };
            int[] blanksRow9 = { 901, 902, 903, 907, 908, 909, 910, 911, 912 };

            return blanksRow1.Concat(blanksRow2)
                             .Concat(blanksRow3)
                             .Concat(blanksRow7)
                             .Concat(blanksRow8)
                             .Concat(blanksRow9)
                             .ToArray();
        }


        public StringBuilder BuildTheArray(IEnumerable<Position>? positions)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Position position in positions)
            {
                Colour xy = position.ColourMatrix.xyPlane;
                Colour xz = position.ColourMatrix.xzPlane;
                Colour yz = position.ColourMatrix.yzPlane;
                //Console.WriteLine($"{position?.Coordinates?.ToString()} - ({xy.ToAbbr()}, {xz.ToAbbr()}, {yz.ToAbbr()})");


                // 12 x 9 grid.
                int rows = 9;
                int cols = 12;

                int[] blanks = GetBlankSquares();


                for (int i = 1; i <= rows; i++)
                {
                    for (int j = 1; j <= cols; j++)
                    {
                        if (blanks.Contains((i * 100 + j)))
                            sb.Append($"         ");
                        else
                            sb.Append($" _______ ");
                    }
                    sb.AppendLine();


                    for (int j = 1; j <= cols; j++)
                    {
                        if (blanks.Contains((i * 100 + j)))
                            sb.Append($"         ");
                        else
                            sb.Append($"|       |");
                    }
                    sb.AppendLine();


                    for (int j = 1; j <= cols; j++)
                    {
                        int number = (i * 100 + j);
                        if (blanks.Contains(number))
                            sb.Append($"         ");
                        else
                            sb.Append($"| {xy.ToAbbr()},{xz.ToAbbr()},{yz.ToAbbr()} |");
                    }
                    sb.AppendLine();


                    for (int j = 1; j <= cols; j++)
                    {
                        if (blanks.Contains((i * 100 + j)))
                            sb.Append($"         ");
                        else
                            sb.Append($"|_______|");
                    }
                    sb.AppendLine();

                }
            }
            return sb;
        }
    }

}