namespace RubikCube
{

    public class Cube
    {
        private readonly IDraw _draw;
        private IEnumerable<Position>? _positions;

        public Cube(IDraw draw)
        {
            _draw = draw;
            InitialiseCube();
        }

        private void InitialiseCube()
        {
            InitialiseCubePositions();
            foreach (var position in _positions)
            {
                InitialiseCubeColours(position);
            }
        }


        private void InitialiseCubePositions()
        {
            List<Position> positions = new List<Position>();
            int[] coordArray = { -1, 0, 1 };
            foreach (var x in coordArray)
            {
                foreach (var y in coordArray)
                {
                    foreach (var z in coordArray)
                    {
                        Position position = new Position()
                        {
                            Coordinates = new Tuple<int, int, int>(x, y, z),
                            ColourMatrix = new ColourMatrix()
                        };
                        positions.Add(position);
                    }
                }
            }
            _positions = positions.AsEnumerable<Position>();

        }

        private void InitialiseCubeColours(Position position)
        {
            int xCoordinate = position.Coordinates.Item1;
            int yCoordinate = position.Coordinates.Item2;
            int zCoordinate = position.Coordinates.Item3;

            // Cube always starts the same.
            switch (zCoordinate)  // Front to Back
            {
                case -1: // Front Face
                    position.ColourMatrix.xyPlane = Colour.Green;
                    break;
                case 0: // Middle 'Face'
                    position.ColourMatrix.xyPlane = Colour.Empty;
                    break;
                case 1: // Back Face
                    position.ColourMatrix.xyPlane = Colour.Blue;
                    break;
                default:
                    break;
            }

            switch (yCoordinate)  // Bottom to Top
            {
                case -1: // Bottom Face
                    position.ColourMatrix.xzPlane = Colour.Yellow;
                    break;
                case 0: // Middle 'Face'
                    position.ColourMatrix.xzPlane = Colour.Empty;
                    break;
                case 1: // Top Face
                    position.ColourMatrix.xzPlane = Colour.White;
                    break;
                default:
                    break;
            }

            switch (xCoordinate)  // Left to Right
            {
                case -1: // Left Face
                    position.ColourMatrix.yzPlane = Colour.Orange;
                    break;
                case 0: // Middle 'Face'
                    position.ColourMatrix.yzPlane = Colour.Empty;
                    break;
                case 1: // Right Face
                    position.ColourMatrix.yzPlane = Colour.Red;
                    break;
                default:
                    break;
            }
        }

        public void Display()
        {
            _draw?.Create(_positions);
        }
    }
}