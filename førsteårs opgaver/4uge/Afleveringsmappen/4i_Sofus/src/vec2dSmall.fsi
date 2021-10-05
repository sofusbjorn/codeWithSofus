/// Short answer for 4i0 - a

/// A 2 dimensional vector library.
/// Vectors are represented as pairs of floats
module vec2d
///<summary>Find the length of a vector, v(x,y)  with coordinates x and y, as floats </summary>
///<param name = "x">X-coordinate.</param>
///<param name = "y">Y-coordinate.</param>
///<returns>The length of v(x,y)</returns>
val len : float * float -> float
/// The angle of a vector
///<summary>Find the angle of a vector, v(x,y),  with coordinates x and y, as floats </summary>
///<param name = "x">X-coordinate.</param>
///<param name = "y">Y-coordinate.</param>
///<returns>The angle of v(x,y)</returns>
val ang : float * float -> float
/// Addition of two vectors
///<summary>Find sum/resultant of two vectors,v(x_1,y_1) and v(x_2,y_2) with x and y being floats </summary>
///<param name = "x1">X-coordinate of the first vector.</param>
///<param name = "y1">Y-coordinate of the first vector.</param>
///<param name = "x2">X-coordinate of the second vector.</param>
///<param name = "y2">Y-coordinate of the second vector.</param>
///<returns>The resultant of v(x1,y1) and v(x2,y2)</returns>
val add : float * float -> float * float -> float * float
