let float2cfrac (x : float) : int list =
    let rec recursionFTW (x_i : float) (lst : int list)  : int list =
        
        let (=~) a b = 
            a < b + 0.00000000001 && a > b - 0.00000000001

        let floorButFixedForStupidFloats a =
            floor(a + 0.0000000001)
       
        let q_i = floorButFixedForStupidFloats(x_i) 
        let r_i = x_i - q_i
        if r_i =~ 0.0
        then lst @ [int(q_i)]
        else recursionFTW (1.0/r_i) (lst @ [int(q_i)])

    if x < 0.0 then []
    else recursionFTW x []

printfn "%A" (float2cfrac -1.5)