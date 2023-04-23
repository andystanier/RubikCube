namespace RubikCube
{
    class Program
    {
        static void Main(string[] args)
        {
            // Provide the way in which we will display the Cube.
            Print print = new Print();


            // Initialise a Cube in its starting configuration or with Rotations.
            Cube cube;

            if (args.Any() && args[0].ToLower().Equals("init"))
            {
                cube = new Cube(print, args[0]);
            }
            else if (args.Any() && !args[0].ToLower().Equals("init"))
            {
                throw new ArgumentException($"Invalid Argument '{args[0]}'");
            }
            else
            {
                cube = new Cube(print);
            }

            // Now Display it
            cube.Display();
        }

        // static void Main(string[] args)
        // {
        //     var test = new GetColourFromPositionTest();
        //     System.Console.WriteLine(test.GetColourFromValidPosition());


        // }
    }
}