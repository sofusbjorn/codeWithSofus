/// besvarelse af 4i0 - b
module vec2d
///<summary>Find the length of a vector, v(x,y)  with coordinates x and y, as floats </summary>
///<param name = "x">X-coordinate.</param>
///<param name = "y">Y-coordinate.</param>
///<returns>The length of v(x,y)</returns>
let len ((x,y) : float * float) : float =
    let xRes = (x) ** 2.0
    let yRes = (y) ** 2.0
    (sqrt ( xRes + yRes ))


///<summary>Find the angle of a vector, v(x,y),  with coordinates x and y, as floats </summary>
///<param name = "x">X-coordinate.</param>
///<param name = "y">Y-coordinate.</param>
///<returns>The angle of v(x,y)</returns>
let ang ((x,y) : float * float) : float =
    atan2 y x


///<summary>Find sum/resultant of two vectors,v(x_1,y_1) and v(x_2,y_2) with x and y being floats </summary>
///<param name = "x1">X-coordinate of the first vector.</param>
///<param name = "y1">Y-coordinate of the first vector.</param>
///<param name = "x2">X-coordinate of the second vector.</param>
///<param name = "y2">Y-coordinate of the second vector.</param>
///<returns>The resultant of v(x1,y1) and v(x2,y2)</returns>
let add ((x1,y1) : float * float) ((x2,y2) : float * float) : float * float =
  let  x3 = x1 + x2
  let  y3 = y1 + y2
  (x3,y3)
