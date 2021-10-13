module continuedFraction

let rec cfrac2float (lst : int list) : float =
    match lst with
    | [] -> 0.0
    | x::xs when List.contains 0 xs -> 0.0
    | [x] -> float(x)
    | x::xs -> float(x) + 1.0/float(cfrac2float(xs))

let float2cfrac (x : float) : int list =
    let rec recursionFTW (x_i : float) (lst : int list)  : int list =

        let q_i = (floor(System.Math.Round (x_i, 6))) 
        let r_i = System.Math.Round (x_i, 6) - q_i
        if abs r_i < 1e-10
        then lst @ [int(q_i)]
        else recursionFTW (1.0/r_i) (lst @ [int(q_i)])

    recursionFTW x []