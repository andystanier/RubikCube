namespace RubikCube
{
    public interface IDraw
    {
        void Create(IEnumerable<Face> faces, string? argument = null);
    }


}