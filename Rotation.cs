namespace RubikCube
{
    public class Rotation
    {
        private IEnumerable<Face>? _faces;

        public Rotation(IEnumerable<Face>? faces)
        {
            _faces = faces;
        }

        public void Rotate(Face face, Direction direction)
        {
            // If this is the front face turning 
            if (face.Abbreviation == 'F')
            {
                // The xyPlane will not change
                // The xy and zy planes for each of L,R,U and D faces will change but only for the position where the Z index is -1
                if (direction == Direction.Clockwise)  // for Clockwise Rotation.
                {
                    /********************************************************************************************************************************/
                    // the xzPlane on the Up face where Z-index = -1 will change to be what the yzPlane was on the left face where z index is -1
                    IEnumerable<Colour>? xzUpColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).ToList().Select(m => m.xzPlane);
                    IEnumerable<Colour>? yzLeftPlaneLeftFront = _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).ToList().Select(co => co.ColourMatrix).Select(m => m.yzPlane);

                    // the yzPlane on the Left face where Z-index = -1 will change to be what the xzPlane was on the Down face where Z-index = -1 
                    IEnumerable<Colour>? yzLeftColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).ToList().Select(m => m.yzPlane);
                    IEnumerable<Colour>? xzDownPlaneLeftFront = _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).ToList().Select(co => co.ColourMatrix).Select(m => m.xzPlane);

                    // the xzPlane on the Down face where Z-index = -1 will change to be what the yzPlane was on the right face where Z-index = -1 
                    IEnumerable<Colour>? xzDownColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).ToList().Select(m => m.xzPlane);
                    IEnumerable<Colour>? yzRightPlaneLeftFront = _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).ToList().Select(co => co.ColourMatrix).Select(m => m.yzPlane);

                    // the yzPlane on the Right face where Z-index = -1 will change to be what the xzPlane was on the Up face where Z-index = -1 
                    IEnumerable<Colour>? yzRightColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).ToList().Select(m => m.yzPlane);
                    IEnumerable<Colour>? xzUpPlaneLeftFront = _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).ToList().Select(co => co.ColourMatrix).Select(m => m.xzPlane);

                    List<Colour> xzUpUpdatedColours = new List<Colour>();
                    List<Colour> yzLeftUpdatedColours = new List<Colour>();
                    List<Colour> xzDownUpdatedColours = new List<Colour>();
                    List<Colour> yzRightUpdatedColours = new List<Colour>();

                    // the xzPlane on the Up face where Z-index = -1 will change to be what the yzPlane was on the left face where z index is -1
                    // the yzPlane on the Left face where Z-index = -1 will change to be what the xzPlane was on the Down face where Z-index = -1 
                    // the xzPlane on the Down face where Z-index = -1 will change to be what the yzPlane was on the right face where Z-index = -1 
                    // the yzPlane on the Right face where Z-index = -1 will change to be what the xzPlane was on the Up face where Z-index = -1 

                    for (int i = 0; i < 3; i++)
                    {
                        xzUpUpdatedColours.Add(yzLeftPlaneLeftFront.ToList()[i]);
                        yzLeftUpdatedColours.Add(xzDownPlaneLeftFront.ToList()[i]);
                        xzDownUpdatedColours.Add(yzRightPlaneLeftFront.ToList()[i]);
                        yzRightUpdatedColours.Add(xzUpPlaneLeftFront.ToList()[i]);
                    }

                    xzUpColoursToChange = xzUpUpdatedColours.AsEnumerable();
                    yzLeftColoursToChange = yzLeftUpdatedColours.AsEnumerable();
                    xzDownColoursToChange = xzDownUpdatedColours.AsEnumerable();
                    yzRightColoursToChange = yzRightUpdatedColours.AsEnumerable();

                    _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 1).Where(p => p.Coordinates.Item1 == -1).ToList().ForEach(p => p.ColourMatrix.xzPlane = xzUpColoursToChange.ToList()[0]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 1).Where(p => p.Coordinates.Item1 == 0).ToList().ForEach(p => p.ColourMatrix.xzPlane = xzUpColoursToChange.ToList()[1]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 1).Where(p => p.Coordinates.Item1 == 1).ToList().ForEach(p => p.ColourMatrix.xzPlane = xzUpColoursToChange.ToList()[2]);

                    /********************************************************************************************************************************/
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 1).Where(p => p.Coordinates.Item1 == -1).ToList().ForEach(p => p.ColourMatrix.yzPlane = yzLeftColoursToChange.ToList()[0]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 0).Where(p => p.Coordinates.Item1 == -1).ToList().ForEach(p => p.ColourMatrix.yzPlane = yzLeftColoursToChange.ToList()[1]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == -1).Where(p => p.Coordinates.Item1 == -1).ToList().ForEach(p => p.ColourMatrix.yzPlane = yzLeftColoursToChange.ToList()[2]);

                    /********************************************************************************************************************************/
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == -1).Where(p => p.Coordinates.Item1 == -1).ToList().ForEach(p => p.ColourMatrix.xzPlane = xzDownColoursToChange.ToList()[0]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == -1).Where(p => p.Coordinates.Item1 == 0).ToList().ForEach(p => p.ColourMatrix.xzPlane = xzDownColoursToChange.ToList()[1]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == -1).Where(p => p.Coordinates.Item1 == 1).ToList().ForEach(p => p.ColourMatrix.xzPlane = xzDownColoursToChange.ToList()[2]);

                    /********************************************************************************************************************************/
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == -1).Where(p => p.Coordinates.Item1 == 1).ToList().ForEach(p => p.ColourMatrix.yzPlane = yzRightColoursToChange.ToList()[0]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 0).Where(p => p.Coordinates.Item1 == 1).ToList().ForEach(p => p.ColourMatrix.yzPlane = yzRightColoursToChange.ToList()[1]);
                    _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).Where(p => p.Coordinates.Item2 == 1).Where(p => p.Coordinates.Item1 == 1).ToList().ForEach(p => p.ColourMatrix.yzPlane = yzRightColoursToChange.ToList()[2]);

                    /********************************************************************************************************************************/
                }
                else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
                {

                    // We aren't performing a front-face anticlockwise in this example so this was skipped for time reasons
                    /********************************************************************************************************************************/
                    // the xzPlane on the Up face where Z-index = -1 will change to be what the yzPlane was on the Right face where Z-index = -1 

                    /********************************************************************************************************************************/
                    // the yzPlane on the Left face where Z-index = -1 will change to be what the xzPlane was on the Up facewhere Z-index = -1 

                    /********************************************************************************************************************************/
                    // the xzPlane on the Down face where Z-index = -1 will change to be what the yzPlane was on the Left face where Z-index = -1 

                    /********************************************************************************************************************************/
                    // the yzPlane on the Right face where Z-index = -1 will change to be what the xzPlane was on the Down face where Z-index = -1 

                    /********************************************************************************************************************************/


                }

            }

        }

    }
}