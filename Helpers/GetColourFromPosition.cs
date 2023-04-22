namespace RubikCube
{
    public class GetColourFromPosition
    {
        private readonly Position _position;
        public GetColourFromPosition(Position position)
        {
            _position = position;
            UnboxColours();
        }

        // private int xCoordinate { get; set; }
        // private int yCoordinate { get; set; }
        // private int zCoordinate { get; set; }

        public Colour xyPlane { get; private set; }
        public Colour xzPlane { get; private set; }
        public Colour yzPlane { get; private set; }

        // private void UnboxPosition()
        // {
        //     xCoordinate = _position.Coordinates.Item1;
        //     yCoordinate = _position.Coordinates.Item2;
        //     zCoordinate = _position.Coordinates.Item3;
        // }

        private void UnboxColours()
        {
            xyPlane = _position.ColourMatrix.xyPlane;
            xzPlane = _position.ColourMatrix.xzPlane;
            yzPlane = _position.ColourMatrix.yzPlane;
        }

    }
}