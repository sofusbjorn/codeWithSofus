open vec2d

let (=~) a b =
    a < b + 0.00001 && a > b - 0.00001

printfn "black-box testeing of the vec2d library"
printfn "The length function"
printfn " %5b: x=3 y=4" (len (3.0,4.0) = 5.0)
printfn " %5b: x=0 y=0" (len (0.0,0.0) = 0.0)
printfn " %5b: x=-3 y=-4" (len ((-3.0),(-4.0)) = 5.0)
printfn " %5b: x=-6 y=8" (len (-6.0,8.0) = 10.0)
printfn " %5b: x=8 y=-6" (len (8.0,-6.0) = 10.0)
printfn " "
printfn "The angle function"
printfn " %5b: y=5 x=5" (ang (5.0,5.0) =~ 0.785398163397)
printfn " %5b: y=-5 x=-5" (ang (-5.0,-5.0) =~ -2.356194490192)
printfn " %5b: y=5 x=-10" (ang (-10.0,5.0) =~ 2.677945044589)
printfn " %5b: y=-5 x=10" (ang (10.0,-5.0) =~  -0.463647609001)
printfn " %5b: y=0 x=0" (ang (0.0,0.0) =~ 0.0)
printfn " "
printfn "The addition function"
printfn " %5b: (5,5) + (5,5)" (add (5.0,5.0) (5.0,5.0) = (10.0,10.0))
printfn " %5b: (-5,-5) + (5,5)" (add (-5.0,-5.0) (5.0,5.0) = (0.0,0.0))
printfn " %5b: (-5,-5) + (-5,-5)" (add (-5.0,-5.0) (-5.0,-5.0) = (-10.0 ,-10.0))
printfn " %5b: (0,0) + (0,0)" (add (0.0,0.0) (0.0,0.0) = (0.0,0.0))
