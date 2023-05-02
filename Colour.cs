namespace RubikCube
{
    public enum Colour
    {
        Green = 1,
        White,
        Red,
        Orange,
        Yellow,
        Blue,
        Empty,
    }

    public static class ColourExtension
    {
        public static char ToAbbr(this Colour colour)
        {
            return colour.ToString().ToCharArray().First();
        }
    }
}