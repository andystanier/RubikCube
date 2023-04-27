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

## Transformed State

When no arguments are passed, the Rubiks Cube will perform the following face rotations and will display the solution to the user.

- Front face clockwise 90<sup>o</sup>
- Right face anti-clockwise 90<sup>o</sup>
- Up face clockwise 90<sup>o</sup>
- Back face anti-clockwise 90<sup>o</sup>
- Left face clockwise 90<sup>o</sup>
- Down face anti-clockwise 90<sup>o</sup>
