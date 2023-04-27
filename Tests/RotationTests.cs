namespace RubikCube
{
    public class RotationTests
    {
        private List<KeyValuePair<int, string>> _coloursInGrid = new List<KeyValuePair<int, string>>();

        List<Face> _faces;
        public RotationTests(List<Face> faces)
        {
            _faces = faces;
            ConnectPositionsAndColoursToGrid();
        }

        public void ShowOutput(Dictionary<int, string> answer)
        {

            Dictionary<int, string> wrong = new Dictionary<int, string>();

            bool isStateCorrect = true;

            foreach (var colourkvp in _coloursInGrid)
            {
                if (answer[colourkvp.Key] != colourkvp.Value)
                {
                    isStateCorrect = false;
                    wrong.Add(colourkvp.Key, colourkvp.Value);
                }
            }
            string formattedMessage = isStateCorrect ? "" : "in";
            Console.WriteLine($"The solution is {formattedMessage}correct");

            if (!isStateCorrect)
            {
                Console.WriteLine($"There are {wrong.Count} incorrect out of {answer.Count}.  The following are wrong:");
                foreach (var item in wrong)
                {
                    Console.Write(item);
                    Console.WriteLine($" Should be {answer[item.Key]}");

                }

            }
        }

        public void CheckStateAfterFC()
        {
            Dictionary<int, string> answer = FClock();
            ShowOutput(answer);
        }

        public void CheckStateAfterFC_RA()
        {
            Dictionary<int, string> answer = FClock_RAnti();
            ShowOutput(answer);
        }

        public void CheckFinalState()
        {
            Dictionary<int, string> answer = TheAnswer();
            ShowOutput(answer);
        }

        private void ConnectPositionsAndColoursToGrid()
        {
            // We need to map the PositionMatrix values of each face to the Grid that we"re using to visualise.
            // This won't be pretty.

            // List<KeyValuePair<int, Tuple<int, int, int>>> positionInGrid = new List<KeyValuePair<int, Tuple<int, int, int>>>();
            List<KeyValuePair<int, string>> coloursInGrid = new List<KeyValuePair<int, string>>();

            List<int> leftFaceIndexes = new List<int>() { 603, 602, 601, 503, 502, 501, 403, 402, 401 };
            List<int> rightFaceIndexes = new List<int>() { 607, 608, 609, 507, 508, 509, 407, 408, 409 };
            List<int> frontFaceIndexes = new List<int>() { 604, 504, 404, 605, 505, 405, 606, 506, 406 };
            List<int> backFaceIndexes = new List<int>() { 612, 512, 412, 611, 511, 411, 610, 510, 410 };
            List<int> upFaceIndexes = new List<int>() { 304, 204, 104, 305, 205, 105, 306, 206, 106 };
            List<int> downFaceIndexes = new List<int>() { 704, 804, 904, 705, 805, 905, 706, 806, 906 };


            Face frontFace = _faces.FirstOrDefault(f => f.Abbreviation == 'F');
            Face backFace = _faces.FirstOrDefault(f => f.Abbreviation == 'B');
            Face upFace = _faces.FirstOrDefault(f => f.Abbreviation == 'U');
            Face downFace = _faces.FirstOrDefault(f => f.Abbreviation == 'D');
            Face leftFace = _faces.FirstOrDefault(f => f.Abbreviation == 'L');
            Face rightFace = _faces.FirstOrDefault(f => f.Abbreviation == 'R');


            List<string> frontColours = frontFace.Positions.Select(p => $"{p.ColourMatrix.xyPlane.ToAbbr()}").ToList();
            List<string> backColours = backFace.Positions.Select(p => $"{p.ColourMatrix.xyPlane.ToAbbr()}").ToList();
            List<string> upColours = upFace.Positions.Select(p => $"{p.ColourMatrix.xzPlane.ToAbbr()}").ToList();
            List<string> downColours = downFace.Positions.Select(p => $"{p.ColourMatrix.xzPlane.ToAbbr()}").ToList();
            List<string> leftColours = leftFace.Positions.Select(p => $"{p.ColourMatrix.yzPlane.ToAbbr()}").ToList();
            List<string> rightColours = rightFace.Positions.Select(p => $"{p.ColourMatrix.yzPlane.ToAbbr()}").ToList();


            for (int i = 0; i < 9; i++)
            {
                coloursInGrid.Add(new KeyValuePair<int, string>(frontFaceIndexes[i], frontColours[i]));
                coloursInGrid.Add(new KeyValuePair<int, string>(backFaceIndexes[i], backColours[i]));
                coloursInGrid.Add(new KeyValuePair<int, string>(upFaceIndexes[i], upColours[i]));
                coloursInGrid.Add(new KeyValuePair<int, string>(downFaceIndexes[i], downColours[i]));
                coloursInGrid.Add(new KeyValuePair<int, string>(leftFaceIndexes[i], leftColours[i]));
                coloursInGrid.Add(new KeyValuePair<int, string>(rightFaceIndexes[i], rightColours[i]));
            }

            _coloursInGrid = coloursInGrid;
        }
        private Dictionary<int, string> FClock()
        {
            return new Dictionary<int, string>(){

                {104, "W"},
                {105, "W"},
                {106, "W"},
                {204, "W"},
                {205, "W"},
                {206, "W"},
                {304, "O"},
                {305, "O"},
                {306, "O"},

                {401, "O"},
                {402, "O"},
                {403, "Y"},
                {501, "O"},
                {502, "O"},
                {503, "Y"},
                {601, "O"},
                {602, "O"},
                {603, "Y"},

                {404, "G"},
                {405, "G"},
                {406, "G"},
                {504, "G"},
                {505, "G"},
                {506, "G"},
                {604, "G"},
                {605, "G"},
                {606, "G"},

                {407, "W"},
                {408, "R"},
                {409, "R"},
                {507, "W"},
                {508, "R"},
                {509, "R"},
                {607, "W"},
                {608, "R"},
                {609, "R"},

                {410, "B"},
                {411, "B"},
                {412, "B"},
                {510, "B"},
                {511, "B"},
                {512, "B"},
                {610, "B"},
                {611, "B"},
                {612, "B"},

                {704, "R"},
                {705, "R"},
                {706, "R"},
                {804, "Y"},
                {805, "Y"},
                {806, "Y"},
                {904, "Y"},
                {905, "Y"},
                {906, "Y"}

            };

        }

        private Dictionary<int, string> FClock_RAnti()
        {
            return new Dictionary<int, string>(){

                {104, "W"},
                {105, "W"},
                {106, "B"},
                {204, "W"},
                {205, "W"},
                {206, "B"},
                {304, "O"},
                {305, "O"},
                {306, "B"},

                {401, "O"},
                {402, "O"},
                {403, "Y"},
                {501, "O"},
                {502, "O"},
                {503, "Y"},
                {601, "O"},
                {602, "O"},
                {603, "Y"},

                {404, "G"},
                {405, "G"},
                {406, "W"},
                {504, "G"},
                {505, "G"},
                {506, "W"},
                {604, "G"},
                {605, "G"},
                {606, "O"},

                {407, "R"},
                {408, "R"},
                {409, "R"},
                {507, "R"},
                {508, "R"},
                {509, "R"},
                {607, "W"},
                {608, "W"},
                {609, "W"},

                {410, "Y"},
                {411, "B"},
                {412, "B"},
                {510, "Y"},
                {511, "B"},
                {512, "B"},
                {610, "R"},
                {611, "B"},
                {612, "B"},

                {704, "R"},
                {705, "R"},
                {706, "G"},
                {804, "Y"},
                {805, "Y"},
                {806, "G"},
                {904, "Y"},
                {905, "Y"},
                {906, "G"}

            };

        }

        private Dictionary<int, string> FClock_RAnti_UClock()
        {
            return new Dictionary<int, string>(){

                {104, "O"},
                {105, "W"},
                {106, "W"},
                {204, "O"},
                {205, "W"},
                {206, "W"},
                {304, "B"},
                {305, "B"},
                {306, "B"},

                {401, "G"},
                {402, "G"},
                {403, "W"},
                {501, "O"},
                {502, "O"},
                {503, "Y"},
                {601, "O"},
                {602, "O"},
                {603, "Y"},

                {404, "R"},
                {405, "R"},
                {406, "R"},
                {504, "G"},
                {505, "G"},
                {506, "W"},
                {604, "G"},
                {605, "G"},
                {606, "O"},

                {407, "Y"},
                {408, "B"},
                {409, "B"},
                {507, "R"},
                {508, "R"},
                {509, "R"},
                {607, "W"},
                {608, "W"},
                {609, "W"},

                {410, "O"},
                {411, "O"},
                {412, "Y"},
                {510, "Y"},
                {511, "B"},
                {512, "B"},
                {610, "R"},
                {611, "B"},
                {612, "B"},

                {704, "R"},
                {705, "R"},
                {706, "G"},
                {804, "Y"},
                {805, "Y"},
                {806, "G"},
                {904, "Y"},
                {905, "Y"},
                {906, "G"}

            };

        }

        private Dictionary<int, string> FClock_RAnti_UClock_BAnti()
        {
            return new Dictionary<int, string>(){

                {104, "O"},
                {105, "O"},
                {106, "G"},
                {204, "O"},
                {205, "W"},
                {206, "W"},
                {304, "B"},
                {305, "B"},
                {306, "B"},

                {401, "Y"},
                {402, "G"},
                {403, "W"},
                {501, "Y"},
                {502, "O"},
                {503, "Y"},
                {601, "G"},
                {602, "O"},
                {603, "Y"},

                {404, "R"},
                {405, "R"},
                {406, "R"},
                {504, "G"},
                {505, "G"},
                {506, "W"},
                {604, "G"},
                {605, "G"},
                {606, "O"},

                {407, "Y"},
                {408, "B"},
                {409, "O"},
                {507, "R"},
                {508, "R"},
                {509, "W"},
                {607, "W"},
                {608, "W"},
                {609, "W"},

                {410, "Y"},
                {411, "B"},
                {412, "B"},
                {510, "O"},
                {511, "B"},
                {512, "B"},
                {610, "O"},
                {611, "Y"},
                {612, "R"},

                {704, "R"},
                {705, "R"},
                {706, "G"},
                {804, "Y"},
                {805, "Y"},
                {806, "G"},
                {904, "W"},
                {905, "R"},
                {906, "B"}

            };

        }

        private Dictionary<int, string> FClock_RAnti_UClock_BAnti_LClock()
        {
            return new Dictionary<int, string>(){

                {104, "R"},
                {105, "O"},
                {106, "G"},
                {204, "B"},
                {205, "W"},
                {206, "W"},
                {304, "B"},
                {305, "B"},
                {306, "B"},

                {401, "G"},
                {402, "Y"},
                {403, "Y"},
                {501, "O"},
                {502, "O"},
                {503, "G"},
                {601, "Y"},
                {602, "Y"},
                {603, "W"},

                {404, "O"},
                {405, "R"},
                {406, "R"},
                {504, "O"},
                {505, "G"},
                {506, "W"},
                {604, "B"},
                {605, "G"},
                {606, "O"},

                {407, "Y"},
                {408, "B"},
                {409, "O"},
                {507, "R"},
                {508, "R"},
                {509, "W"},
                {607, "W"},
                {608, "W"},
                {609, "W"},

                {410, "Y"},
                {411, "B"},
                {412, "W"},
                {510, "O"},
                {511, "B"},
                {512, "Y"},
                {610, "O"},
                {611, "Y"},
                {612, "R"},

                {704, "R"},
                {705, "R"},
                {706, "G"},
                {804, "G"},
                {805, "Y"},
                {806, "G"},
                {904, "G"},
                {905, "R"},
                {906, "B"}

            };

        }

        private Dictionary<int, string> FClock_RAnti_UClock_BAnti_LClock_DAnti()
        {
            return new Dictionary<int, string>(){

                {104, "R"},
                {105, "O"},
                {106, "G"},
                {204, "B"},
                {205, "W"},
                {206, "W"},
                {304, "B"},
                {305, "B"},
                {306, "B"},

                {401, "G"},
                {402, "Y"},
                {403, "Y"},
                {501, "O"},
                {502, "O"},
                {503, "G"},
                {601, "B"},
                {602, "G"},
                {603, "O"},

                {404, "O"},
                {405, "R"},
                {406, "R"},
                {504, "O"},
                {505, "G"},
                {506, "W"},
                {604, "W"},
                {605, "W"},
                {606, "W"},

                {407, "Y"},
                {408, "B"},
                {409, "O"},
                {507, "R"},
                {508, "R"},
                {509, "W"},
                {607, "O"},
                {608, "Y"},
                {609, "R"},

                {410, "Y"},
                {411, "B"},
                {412, "W"},
                {510, "O"},
                {511, "B"},
                {512, "Y"},
                {610, "Y"},
                {611, "Y"},
                {612, "W"},

                {704, "G"},
                {705, "G"},
                {706, "B"},
                {804, "R"},
                {805, "Y"},
                {806, "R"},
                {904, "R"},
                {905, "G"},
                {906, "G"}

            };

        }

        private Dictionary<int, string> TheAnswer()
        {
            return new Dictionary<int, string>(){

                {104, "R"},
                {105, "O"},
                {106, "G"},
                {204, "B"},
                {205, "W"},
                {206, "W"},
                {304, "B"},
                {305, "B"},
                {306, "B"},

                {401, "G"},
                {402, "Y"},
                {403, "Y"},
                {501, "O"},
                {502, "O"},
                {503, "G"},
                {601, "B"},
                {602, "G"},
                {603, "O"},

                {404, "O"},
                {405, "R"},
                {406, "R"},
                {504, "O"},
                {505, "G"},
                {506, "W"},
                {604, "W"},
                {605, "W"},
                {606, "W"},

                {407, "Y"},
                {408, "B"},
                {409, "O"},
                {507, "R"},
                {508, "R"},
                {509, "W"},
                {607, "O"},
                {608, "Y"},
                {609, "R"},

                {410, "Y"},
                {411, "B"},
                {412, "W"},
                {510, "O"},
                {511, "B"},
                {512, "Y"},
                {610, "Y"},
                {611, "Y"},
                {612, "W"},

                {704, "G"},
                {705, "G"},
                {706, "B"},
                {804, "R"},
                {805, "Y"},
                {806, "R"},
                {904, "R"},
                {905, "G"},
                {906, "G"}

            };

        }
    }

}