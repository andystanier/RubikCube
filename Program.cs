namespace RubikCube
{
    class Program
    {
        static void Main(string[] args)
        {
            // Provide the way in which we will display the Cube.
            Print print = new Print();

            // Initialise a Cube in it's starting configuration.
            Cube cube = new Cube(print);

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