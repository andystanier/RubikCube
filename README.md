# RubikCube

## Getting Started

The Rubik Cube solution is written in .NET 6.

Assuming you have the .NET 6 SDK installed, you can run the program by simply downloading the publish folder from GitHub and then open a terminal in that location.

In Powershell type 
> `./RubikCube.exe`

In Bash type 
> `./RubikCube`

To avoid word-wrap anomolies, make your terminal full screen.

## Output

The output that you will see is a 2D representation of the cube. 
The layout shows the faces in the following order

>``` 
>                _____
>               |     |
>               |  U  |                     
>               |_____|                         L - Left
>         _____  _____  _____  _____            F - Front
>        |     ||     ||     ||     |           U - Up
>        |  L  ||  F  ||  R  ||  B  |           B - Back
>        |_____||_____||_____||_____|           D - Down
>                _____                          R - Right
>               |     |                     
>               |  D  |
>               |_____|
>
>```

Each face is split into 9 squares displaying a colour.

Each colour is represented by a single character as shown

- G - Green
- W - White
- B - Blue
- Y - Yellow
- O - Orange
- R - Red

## Initial State

You can see the initial state of the cube by passing `"init"` as an argument when running the program from the console.

> `./RubikCube "init"`


## Tests

Some tests were written to help me determine whether I had correctly implemented the desired rotations.  These were accessed by adding `"Test"` as an argument at the console or by altering `launch.json` accordingly.

Ideally this would be done as a second project and using XUnit or NUnit or any other Testing package, but due to time constraints I went down the path of just adding arguments to the program.


## Transformed State

When no arguments are passed, the Rubiks Cube will perform the following face rotations and will display the solution to the user.

- Front face clockwise 90<sup>o</sup>
- Right face anti-clockwise 90<sup>o</sup>


Due to time constraints, I was unable to implement the last 4 steps and so the display will present the state of the cube after just these two.

The following rotations are NOT included.

- Up face clockwise 90<sup>o</sup>
- Back face anti-clockwise 90<sup>o</sup>
- Left face clockwise 90<sup>o</sup>
- Down face anti-clockwise 90<sup>o</sup>

## The Way it is Coded

Personally I'm not really happy with the way it looks.  The code is basically a mess and isn't exactly elegant.  
I started off with a plan of what classes there should be and what they should do and how they ought to interact, but once coding began, I found that the plan wasn't really up to scratch.

I didn't really know how to implement the rotation, which really is the crux of this program.  So the code that does that is sub-optimal at best.  

Perhaps given more time, I would look at refactoring into something a bit more SOLID.  I think I would certainly make a second project for testing purposes and would look at a more elegent way to perform rotations.

There are also many warnings thrown about null or potentially null values, which should be addressed in future versions.