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
            switch (face.Abbreviation)
            {
                case 'F':
                    RotateFront(direction);
                    break;
                case 'R':
                    RotateRight(direction);
                    break;
                case 'U':
                    RotateUp(direction);
                    break;
                case 'B':
                    RotateBack(direction);
                    break;
                case 'L':
                    RotateLeft(direction);
                    break;
                case 'D':
                    RotateDown(direction);
                    break;
                default:
                    break;
            }
        }

        private void RotateFront(Direction direction)
        {
            // The xyPlane will for the F face will change for all positions except the middle (001).
            // The xz and yz planes for each of L,R,U and D faces will change but only for the position where the Z index is -1
            if (direction == Direction.Clockwise)  // for Clockwise Rotation.
            {
                /********************************************************************************************************************************/
                // the xzPlane on the Up face where Z-index = -1 (Front) will change to be what the yzPlane was on the left face where Z index is -1 (Front) 
                IEnumerable<Colour>? xzUpColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).Select(m => m.xzPlane);
                IEnumerable<Colour>? yzLeftFrontPlane = _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(co => co.ColourMatrix).Select(m => m.yzPlane);

                // the yzPlane on the Left face where Z-index = -1 (Front) will change to be what the xzPlane was on the Down face where Z-index = -1 (Front) 
                IEnumerable<Colour>? yzLeftColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'L').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).Select(m => m.yzPlane);
                IEnumerable<Colour>? xzDownFrontPlane = _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(co => co.ColourMatrix).Select(m => m.xzPlane);

                // the xzPlane on the Down face where Z-index = -1 (Front) will change to be what the yzPlane was on the right face where Z-index = -1 (Front) 
                IEnumerable<Colour>? xzDownColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'D').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).Select(m => m.xzPlane);
                IEnumerable<Colour>? yzRightFrontPlane = _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(co => co.ColourMatrix).Select(m => m.yzPlane);

                // the yzPlane on the Right face where Z-index = -1 (Front) will change to be what the xzPlane was on the Up face where Z-index = -1 (Front) 
                IEnumerable<Colour>? yzRightColoursToChange = _faces?.FirstOrDefault(f => f.Abbreviation == 'R').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(p => p.ColourMatrix).Select(m => m.yzPlane);
                IEnumerable<Colour>? xzUpFrontPlane = _faces?.FirstOrDefault(f => f.Abbreviation == 'U').Positions.Where(p => p.Coordinates!.Item3 == -1).Select(co => co.ColourMatrix).Select(m => m.xzPlane);


                // the xyPlane is different
                // We don't want to count the corners twice because they exist on a row and column.  So do the corners and edges once only.

                Colour xyUpLeftCorner = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 1 && p.Coordinates.Item1 == -1).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();
                Colour xyUpRightCorner = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 1 && p.Coordinates.Item1 == 1).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();
                Colour xyDownLeftCorner = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == -1 && p.Coordinates.Item1 == -1).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();
                Colour xyDownRightCorner = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == -1 && p.Coordinates.Item1 == 1).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();

                Colour xyUpEdge = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 1 && p.Coordinates.Item1 == 0).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();
                Colour xyRightEdge = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 0 && p.Coordinates.Item1 == 1).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();
                Colour xyDownEdge = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == -1 && p.Coordinates.Item1 == 0).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();
                Colour xyLeftEdge = (Colour)_faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 0 && p.Coordinates.Item1 == -1).Select(p => p.ColourMatrix).Select(m => m.xyPlane).First();


                List<Colour> xzUpUpdatedColours = new List<Colour>();
                List<Colour> yzLeftUpdatedColours = new List<Colour>();
                List<Colour> xzDownUpdatedColours = new List<Colour>();
                List<Colour> yzRightUpdatedColours = new List<Colour>();

                // the xzPlane on the Up    face Front will change to be what the yzPlane was on the Left  face Front
                // the yzPlane on the Left  face where Z-index = -1 will change to be what the xzPlane was on the Down  face where Z-index = -1 
                // the xzPlane on the Down  face where Z-index = -1 will change to be what the yzPlane was on the Right face where Z-index = -1 
                // the yzPlane on the Right face where Z-index = -1 will change to be what the xzPlane was on the Up    face where Z-index = -1 

                for (int i = 0; i < 3; i++)
                {
                    xzUpUpdatedColours.Add(yzLeftFrontPlane.ToList()[i]);
                    yzLeftUpdatedColours.Add(xzDownFrontPlane.ToList()[i]);
                    xzDownUpdatedColours.Add(yzRightFrontPlane.ToList()[i]);
                    yzRightUpdatedColours.Add(xzUpFrontPlane.ToList()[i]);
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


                // xyUpLeftCorner becomes what xyDownLeftCorner was
                // xyUpRightCorner becomes what xyUpLeftCorner was
                // xyDownLeftCorner becomes what xyDownRightCorner was 
                // xyDownRightCorner becomes what xyUpRightCorner was


                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 1 && p.Coordinates.Item1 == -1).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyDownLeftCorner);
                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 1 && p.Coordinates.Item1 == 1).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyUpLeftCorner);
                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == -1 && p.Coordinates.Item1 == -1).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyDownRightCorner);
                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == -1 && p.Coordinates.Item1 == 1).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyUpRightCorner);

                // xyUpEdge becomes what xyLeftEdge was
                // xyRightEdge becomes what xyUpEdge was
                // xyDownEdge becomes what xyRightEdge was 
                // xyLeftEdge becomes what xyDownEdge was

                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 1 && p.Coordinates.Item1 == 0).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyLeftEdge);
                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 0 && p.Coordinates.Item1 == 1).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyUpEdge);
                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == -1 && p.Coordinates.Item1 == 0).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyRightEdge);
                _faces?.FirstOrDefault(f => f.Abbreviation == 'F').Positions.Where(p => p.Coordinates!.Item2 == 0 && p.Coordinates.Item1 == -1).Select(p => p.ColourMatrix).ToList().ForEach(m => m.xyPlane = xyDownEdge);

            }
            else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
            {
                // We aren't performing a front-face anticlockwise in this example so this was skipped for time reasons
            }
        }

        private void RotateRight(Direction direction)
        {
            // The yzPlane will change all positions except the middle (100)
            // The xy and xz planes for each of U, F, D and B faces will change but only for the position where the X index is 1
            if (direction == Direction.Clockwise)  // for Clockwise Rotation.
            {
                // We aren't performing a right-face clockwise in this example so this was skipped for time reasons
            }
            else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
            {
                /********************************************************************************************************************************/
                // the xzPlane on the Up    face where X-index = 1 will change to be what the xyPlane was on the Back  face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Front face where X-index = 1 will change to be what the xzPlane was on the Up    face where X-index = 1 
                /********************************************************************************************************************************/
                // the xzPlane on the Down  face where X-index = 1 will change to be what the xyPlane was on the Front face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Back  face where X-index = 1 will change to be what the xzPlane was on the Down  face where X-index = 1 
                /********************************************************************************************************************************/

                // yzUpLeftCorner becomes what yzUpLeftCorner was
                // yzUpRightCorner becomes what yzDownRightCorner was
                // yzDownLeftCorner becomes what yzUpRightCorner was 
                // yzDownRightCorner becomes what yzDownLeftCorner was

                // yzUpEdge becomes what yzRightEdge was
                // yzRightEdge becomes what yzDownEdge was
                // yzDownEdge becomes what yzLeftEdge was 
                // yzLeftEdge becomes what yzUpEdge was
            }


        }

        private void RotateUp(Direction direction)
        {
            // The xzPlane will not change  - DONE
            // The xy and yz planes for each of F, B, L and R faces will change but only for the position where the Y index is 1
            if (direction == Direction.Clockwise)  // for Clockwise Rotation.
            {
                /********************************************************************************************************************************/
                // the xzPlane on the Front face where Y-index = 1 will change to be what the xyPlane was on the Back  face where Y-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Back  face where Y-index = 1 will change to be what the xzPlane was on the Up    face where Y-index = 1 
                /********************************************************************************************************************************/
                // the xzPlane on the Left  face where Y-index = 1 will change to be what the xyPlane was on the Front face where Y-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Right face where Y-index = 1 will change to be what the xzPlane was on the Down  face where Y-index = 1 
                /********************************************************************************************************************************/
            }
            else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
            {
                // We aren't performing a Up face anticlockwise in this example so this was skipped for time reasons
            }
        }

        private void RotateBack(Direction direction)
        {
            // The yzPlane will not change
            // The xy and xz planes for each of U,F,D and B faces will change but only for the position where the X index is 1
            if (direction == Direction.Clockwise)  // for Clockwise Rotation.
            {
                // We aren't performing a Back face clockwise in this example so this was skipped for time reasons
            }
            else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
            {
                /********************************************************************************************************************************/
                // the xzPlane on the Up    face where X-index = 1 will change to be what the xyPlane was on the Back  face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Front face where X-index = 1 will change to be what the xzPlane was on the Up    face where X-index = 1 
                /********************************************************************************************************************************/
                // the xzPlane on the Down  face where X-index = 1 will change to be what the xyPlane was on the Front face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Back  face where X-index = 1 will change to be what the xzPlane was on the Down  face where X-index = 1 
                /********************************************************************************************************************************/
            }
        }

        private void RotateLeft(Direction direction)
        {
            // The yzPlane will not change
            // The xy and xz planes for each of U,F,D and B faces will change but only for the position where the X index is 1
            if (direction == Direction.Clockwise)  // for Clockwise Rotation.
            {
                /********************************************************************************************************************************/
                // the xzPlane on the Up    face where X-index = 1 will change to be what the xyPlane was on the Back  face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Front face where X-index = 1 will change to be what the xzPlane was on the Up    face where X-index = 1 
                /********************************************************************************************************************************/
                // the xzPlane on the Down  face where X-index = 1 will change to be what the xyPlane was on the Front face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Back  face where X-index = 1 will change to be what the xzPlane was on the Down  face where X-index = 1 
                /********************************************************************************************************************************/
            }
            else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
            {
                // We aren't performing a Left face anticlockwise in this example so this was skipped for time reasons
            }
        }
        private void RotateDown(Direction direction)
        {
            // The yzPlane will not change
            // The xy and xz planes for each of U,F,D and B faces will change but only for the position where the X index is 1
            if (direction == Direction.Clockwise)  // for Clockwise Rotation.
            {
                // We aren't performing a Down face clockwise in this example so this was skipped for time reasons
            }
            else if (direction == Direction.AntiClockwise) // for Anti-clockwise Rotation.
            {
                /********************************************************************************************************************************/
                // the xzPlane on the Up    face where X-index = 1 will change to be what the xyPlane was on the Back  face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Front face where X-index = 1 will change to be what the xzPlane was on the Up    face where X-index = 1 
                /********************************************************************************************************************************/
                // the xzPlane on the Down  face where X-index = 1 will change to be what the xyPlane was on the Front face where X-index = 1 
                /********************************************************************************************************************************/
                // the xyPlane on the Back  face where X-index = 1 will change to be what the xzPlane was on the Down  face where X-index = 1 
                /********************************************************************************************************************************/
            }
        }

    }
}