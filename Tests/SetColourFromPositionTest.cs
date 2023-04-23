namespace RubikCube
{
    class SetColourFromPositionTest
    {
        public bool SetColourFromValidPosition()
        {
            // Arrange
            Position position = new Position()
            {
                Coordinates = new Tuple<int, int, int>(-1, 1, 0),
                ColourMatrix = new ColourMatrix()
                {
                    xyPlane = Colour.Empty,
                    xzPlane = Colour.White,
                    yzPlane = Colour.Orange
                }

            };

            // Act
            var sut = new GetColourFromPosition(position);

            // Assert
            bool pass = sut.xyPlane == Colour.Empty &&
                        sut.xzPlane == Colour.White &&
                        sut.yzPlane == Colour.Orange;

            return pass;
        }
    }
}
