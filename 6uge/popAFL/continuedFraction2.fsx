let (=~) a b = 
    a < b + 0.00000000001 && a > b - 0.00000000001

let rec cfrac2float (lst : int list) : float =
    match lst with
    | [] -> 0.0
    | x::xs when List.contains 0 xs -> 0.0
    | [x] -> float(x)
    | x::xs -> float(x) + 1.0/float(cfrac2float(xs))

let float2cfrac (x : float) : int list =
    let rec recursionFTW (x_i : float) (lst : int list)  : int list =
        
        let (=~) a b = 
            a < b + 0.00000000001 && a > b - 0.00000000001

        let floorButFixedForStupidFloats a =
            floor(a + 0.0000000001)
       
        let q_i = (floor(System.Math.Round (x_i, 6))) 
        let r_i = x_i - q_i
        if r_i =~ 0.0
        then lst @ [int(q_i)]
        else recursionFTW (1.0/r_i) (lst @ [int(q_i)])

    recursionFTW x []