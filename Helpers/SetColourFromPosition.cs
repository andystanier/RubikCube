namespace RubikCube
{
    public class SetColourFromPosition
    {
        private readonly Position _position;
        public SetColourFromPosition(Position position)
        {
            _position = position;
            UnboxPosition();
        }

        private int xCoordinate { get; set; }
        private int yCoordinate { get; set; }
        private int zCoordinate { get; set; }

        // public Colour xyPlane { get; private set; }
        // public Colour xzPlane { get; private set; }
        // public Colour yzPlane { get; private set; }

        private void UnboxPosition()
        {
            xCoordinate = _position.Coordinates.Item1;
            yCoordinate = _position.Coordinates.Item2;
            zCoordinate = _position.Coordinates.Item3;
        }

        // private void UnboxColours()
        // {
        //     xyPlane = _position.ColourMatrix.xyPlane;
        //     xzPlane = _position.ColourMatrix.xzPlane;
        //     yzPlane = _position.ColourMatrix.yzPlane;
        // }
        private void InitialiseCubeColours(Position position)
        {
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

    }
}