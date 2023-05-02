namespace RubikCube
{
    public class Face : IFace
    {
        public string Name { get; set; }
        public char Abbreviation { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        // public void Rotate(Direction direction)
        // {
        //     // If this is the front face turning 
        //     // The xyPlane will not change

        //     // The current xzPlanes are 
        //     var xzPlanes = Positions.ToList().Select(p => p.ColourMatrix!.xzPlane);
        //     var yzPlanes = Positions.ToList().Select(p => p.ColourMatrix!.yzPlane);

        //     // for Clockwise Rotation.
        //     // the xzPlane on the top face will change to be what the yzPlane was on the left face
        //     // the yzPlane on the left face will change to be what the xzPlane was on the bottom face
        //     // the xzPlane on the bottom face will change to be what the yzPlane was on the right face
        //     // the yzPlane on the right face will change to be what the xzPlane was on the top face

        //     // for Anti-clockwise Rotation.
        //     // the xzPlane on the top face will change to be what the yzPlane was on the right face
        //     // the yzPlane on the left face will change to be what the xzPlane was on the top face
        //     // the xzPlane on the bottom face will change to be what the yzPlane was on the left face
        //     // the yzPlane on the right face will change to be what the xzPlane was on the bottom face


        //     //Positions.ToList().ForEach(p => p.ColourMatrix!.xyPlane = Colour.Red);
        // }
    }
}