namespace RubikCube
{

    public class Cube
    {
        private readonly IDraw? _draw;
        private IEnumerable<Position>? _positions;
        private IEnumerable<Face>? _faces;


        public Cube(IDraw? draw, string? arguments = null)
        {
            _draw = draw;
            _positions = new List<Position>();
            _faces = new List<Face>();
            InitialiseCube();

            // This is not the way to perform tests. Ideally I would have another project with a testing suite etc. but time...
            // By providing an argument at the console interface, we can see different situations
            if (arguments == null)
            {
                PerformRotations();
            }
            else if (arguments.Equals("test"))
            {
                PerformRotations();
                // new RotationTests(_faces.ToList()).CheckStateAfterFC();
                new RotationTests(_faces.ToList()).CheckStateAfterFC_RA();
                //new RotationTests(_faces.ToList()).CheckFinalState();
            }
            else if (arguments.Equals("init"))
            {
                // Don't perform rotations, but print the initial state.
            }
        }

        public void Display(string? argument = null)
        {
            _draw?.Create(_faces!, argument);
        }

        private void PerformRotations()
        {
            Rotation rotation = new Rotation(_faces);

            // Rotations occur on a face.
            if (_faces != null)
            {
                Face frontFace = _faces.First(f => f.Abbreviation == 'F');
                Face backFace = _faces.First(f => f.Abbreviation == 'B');
                Face upFace = _faces.First(f => f.Abbreviation == 'U');
                Face downFace = _faces.First(f => f.Abbreviation == 'D');
                Face leftFace = _faces.First(f => f.Abbreviation == 'L');
                Face rightFace = _faces.First(f => f.Abbreviation == 'R');

                rotation.Rotate(frontFace, Direction.Clockwise);
                rotation.Rotate(rightFace, Direction.AntiClockwise);
                // rotation.Rotate(upFace, Direction.Clockwise);
                // rotation.Rotate(backFace, Direction.AntiClockwise);
                // rotation.Rotate(leftFace, Direction.Clockwise);
                // rotation.Rotate(downFace, Direction.AntiClockwise);
            }
        }

        private void InitialiseCube()
        {
            InitialiseCubePositions();
            CreateFaces();
            InitialiseCubeColours();
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

        private void CreateFaces()
        {
            List<Face> faces = new List<Face>
            {
                new Face()
                {
                    Name = "Front",
                    Abbreviation = 'F',
                    Positions = _positions!.Where(p => p?.Coordinates?.Item3 == -1) //Z index is -1
                },
                new Face()
                {
                    Name = "Back",
                    Abbreviation = 'B',
                    Positions = _positions!.Where(p => p?.Coordinates?.Item3 == 1)  // Z index is 1
                },
                new Face()
                {
                    Name = "Up",
                    Abbreviation = 'U',
                    Positions = _positions!.Where(p => p?.Coordinates?.Item2 == 1)  // Y index is 1
                },
                new Face()
                {
                    Name = "Down",
                    Abbreviation = 'D',
                    Positions = _positions!.Where(p => p?.Coordinates?.Item2 == -1) // Y index is -1
                },
                new Face()
                {
                    Name = "Left",
                    Abbreviation = 'L',
                    Positions = _positions!.Where(p => p?.Coordinates?.Item1 == -1) // X index is -1
                },
                new Face()
                {
                    Name = "Right",
                    Abbreviation = 'R',
                    Positions = _positions!.Where(p => p?.Coordinates?.Item1 == 1) // X index is -1
                }
            };
            _faces = faces.AsEnumerable<Face>();
        }

        private void InitialiseCubeColours()
        {
            foreach (var face in _faces!)
            {
                switch (face?.Name)
                {
                    case "Front":
                        face.Positions.ToList().ForEach(p => p.ColourMatrix!.xyPlane = Colour.Green);
                        break;
                    case "Back":
                        face.Positions.ToList().ForEach(p => p.ColourMatrix!.xyPlane = Colour.Blue);
                        break;
                    case "Up":
                        face.Positions.ToList().ForEach(p => p.ColourMatrix!.xzPlane = Colour.White);
                        break;
                    case "Down":
                        face.Positions.ToList().ForEach(p => p.ColourMatrix!.xzPlane = Colour.Yellow);
                        break;
                    case "Left":
                        face.Positions.ToList().ForEach(p => p.ColourMatrix!.yzPlane = Colour.Orange);
                        break;
                    case "Right":
                        face.Positions.ToList().ForEach(p => p.ColourMatrix!.yzPlane = Colour.Red);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}