namespace RubikCube
{
    public class Face : IFace
    {
        public string Name { get; set; }
        public char Abbreviation { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}