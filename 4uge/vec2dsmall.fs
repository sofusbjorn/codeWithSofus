/// besvarelse af 4i0 - b
module vec2d

let len ((x,y) : float * float) : float =
    let xRes = (x) ** 2.0
    let yRes = (y) ** 2.0
    (sqrt ( xRes + yRes ))



let ang ((x,y) : float * float) : float =
    atan2 y x



let add ((x1,y1) : float * float) ((x2,y2) : float * float) : float * float =
  let  x3 = x1 + x2
  let  y3 = y1 + y2
  (x3,y3)
