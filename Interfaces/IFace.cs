namespace RubikCube
{
    public interface IFace
    {
        string Name { get; set; }
        char Abbreviation { get; set; }
        IEnumerable<Position> Positions { get; set; }
        void Rotate(Direction direction);
    }
}