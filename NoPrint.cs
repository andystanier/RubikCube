namespace RubikCube
{
    public class NoPrint : IDraw
    {
        public void Create(IEnumerable<Face> faces, string? argument = null)
        {
            // This is for testing so no print required
        }
    }
}