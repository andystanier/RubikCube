using System.Text;

namespace RubikCube
{
    public class Print : IDraw
    {
        private IDictionary<int, string> _positionInGrid = new Dictionary<int, string>();
        private IDictionary<int, string> _coloursInGrid = new Dictionary<int, string>();

        public void Create(IEnumerable<Face> faces, string? argument = null)
        {
            // To print in a 2D representation of the Cube.
            StringBuilder sb = BuildTheArray(faces);
            Console.WriteLine(sb.ToString());
        }

        private StringBuilder BuildTheArray(IEnumerable<Face> faces)
        {
            {
                StringBuilder sb = new StringBuilder();
                // 12 x 9 grid.
                int rows = 9;
                int cols = 12;

                ConnectPositionsToGrid(faces);

                int[] blanks = GetBlankSquares();


                for (int i = 1; i <= rows; i++)
                {
                    for (int j = 1; j <= cols; j++)
                    {
                        if (blanks.Contains(i * 100 + j))
                            sb.Append($"            ");
                        else
                            sb.Append($" __________ ");
                    }
                    sb.AppendLine();


                    for (int j = 1; j <= cols; j++)
                    {
                        if (blanks.Contains(i * 100 + j))
                            sb.Append($"            ");
                        else
                            sb.Append($"|          |");
                    }
                    sb.AppendLine();


                    for (int j = 1; j <= cols; j++)
                    {
                        int number = (i * 100 + j);
                        if (blanks.Contains(number))
                            sb.Append($"            ");
                        else
                            sb.Append($"|   {number}    |");
                    }
                    sb.AppendLine();


                    for (int j = 1; j <= cols; j++)
                    {
                        int number = i * 100 + j;
                        if (blanks.Contains(number))
                            sb.Append($"            ");
                        else
                            sb.Append($"| {_positionInGrid[number]} |");
                    }
                    sb.AppendLine();

                    for (int j = 1; j <= cols; j++)
                    {
                        int number = i * 100 + j;
                        if (blanks.Contains(number))
                            sb.Append($"            ");
                        else
                            sb.Append($"|     {_coloursInGrid[number]}    |");
                    }
                    sb.AppendLine();

                    for (int j = 1; j <= cols; j++)
                    {
                        if (blanks.Contains(i * 100 + j))
                            sb.Append($"            ");
                        else
                            sb.Append($"|__________|");
                    }
                    sb.AppendLine();
                }

                return sb;
            }
        }

        private int[] GetBlankSquares()
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


        private void ConnectPositionsToGrid(IEnumerable<Face> faces)
        {
            // We need to map the PositionMatrix values of each face to the Grid that we're using to visualise.
            // This won't be pretty.

            IDictionary<int, string> positionInGrid = new Dictionary<int, string>();
            IDictionary<int, string> coloursInGrid = new Dictionary<int, string>();

            List<int> leftFaceIndexes = new List<int>() { 603, 602, 601, 503, 502, 501, 403, 402, 401 };
            List<int> rightFaceIndexes = new List<int>() { 607, 608, 609, 507, 508, 509, 407, 408, 409 };
            List<int> frontFaceIndexes = new List<int>() { 604, 504, 404, 605, 505, 405, 606, 506, 406 };
            List<int> backFaceIndexes = new List<int>() { 612, 512, 412, 611, 511, 411, 610, 510, 410 };
            List<int> upFaceIndexes = new List<int>() { 304, 204, 104, 305, 205, 105, 306, 206, 106 };
            List<int> downFaceIndexes = new List<int>() { 704, 804, 904, 705, 805, 905, 706, 806, 906 };


            Face frontFace = faces.FirstOrDefault(f => f.Abbreviation == 'F');
            Face backFace = faces.FirstOrDefault(f => f.Abbreviation == 'B');
            Face upFace = faces.FirstOrDefault(f => f.Abbreviation == 'U');
            Face downFace = faces.FirstOrDefault(f => f.Abbreviation == 'D');
            Face leftFace = faces.FirstOrDefault(f => f.Abbreviation == 'L');
            Face rightFace = faces.FirstOrDefault(f => f.Abbreviation == 'R');

            List<string> frontPositions = frontFace.Positions.Select(p => $"{p.Coordinates.Item1:+0;-#},{p.Coordinates.Item2:+0;-#},{p.Coordinates.Item3:+0;-#}").ToList();
            List<string> backPositions = backFace.Positions.Select(p => $"{p.Coordinates.Item1:+0;-#},{p.Coordinates.Item2:+0;-#},{p.Coordinates.Item3:+0;-#}").ToList();
            List<string> upPositions = upFace.Positions.Select(p => $"{p.Coordinates.Item1:+0;-#},{p.Coordinates.Item2:+0;-#},{p.Coordinates.Item3:+0;-#}").ToList();
            List<string> downPositions = downFace.Positions.Select(p => $"{p.Coordinates.Item1:+0;-#},{p.Coordinates.Item2:+0;-#},{p.Coordinates.Item3:+0;-#}").ToList();
            List<string> leftPositions = leftFace.Positions.Select(p => $"{p.Coordinates.Item1:+0;-#},{p.Coordinates.Item2:+0;-#},{p.Coordinates.Item3:+0;-#}").ToList();
            List<string> rightPositions = rightFace.Positions.Select(p => $"{p.Coordinates.Item1:+0;-#},{p.Coordinates.Item2:+0;-#},{p.Coordinates.Item3:+0;-#}").ToList();

            List<string> frontColours = frontFace.Positions.Select(p => $"{p.ColourMatrix.xyPlane.ToAbbr()}").ToList();
            List<string> backColours = backFace.Positions.Select(p => $"{p.ColourMatrix.xyPlane.ToAbbr()}").ToList();
            List<string> upColours = upFace.Positions.Select(p => $"{p.ColourMatrix.xzPlane.ToAbbr()}").ToList();
            List<string> downColours = downFace.Positions.Select(p => $"{p.ColourMatrix.xzPlane.ToAbbr()}").ToList();
            List<string> leftColours = leftFace.Positions.Select(p => $"{p.ColourMatrix.yzPlane.ToAbbr()}").ToList();
            List<string> rightColours = rightFace.Positions.Select(p => $"{p.ColourMatrix.yzPlane.ToAbbr()}").ToList();


            for (int i = 0; i < 9; i++)
            {
                positionInGrid.Add(frontFaceIndexes[i], frontPositions[i]);
                positionInGrid.Add(backFaceIndexes[i], backPositions[i]);
                positionInGrid.Add(upFaceIndexes[i], upPositions[i]);
                positionInGrid.Add(downFaceIndexes[i], downPositions[i]);
                positionInGrid.Add(leftFaceIndexes[i], leftPositions[i]);
                positionInGrid.Add(rightFaceIndexes[i], rightPositions[i]);

                coloursInGrid.Add(frontFaceIndexes[i], frontColours[i]);
                coloursInGrid.Add(backFaceIndexes[i], backColours[i]);
                coloursInGrid.Add(upFaceIndexes[i], upColours[i]);
                coloursInGrid.Add(downFaceIndexes[i], downColours[i]);
                coloursInGrid.Add(leftFaceIndexes[i], leftColours[i]);
                coloursInGrid.Add(rightFaceIndexes[i], rightColours[i]);
            }

            _positionInGrid = positionInGrid;
            _coloursInGrid = coloursInGrid;
        }
    }
}