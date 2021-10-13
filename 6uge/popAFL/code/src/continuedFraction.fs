/// modulet continuedFraction skabes
module continuedFraction

///<summary> Udregner den kontinuære brøk ud fra en inputtet int list, gennem rekursion </summary>
///<param name = "lst">En integer liste.</param>
///<returns>Den tilsvarende float</returns>
let rec cfrac2float (lst : int list) : float =
    match lst with
    | [] -> 0.0
    | [x] -> float(x)
    | x::xs -> float(x) + 1.0/cfrac2float(xs)

///<summary> Finder den tilsvarende kontinuære brøk ud fra en inputtet float, gennem rekursion </summary>
///<param name = "x">Reelt tal i form af Float.</param>
///<returns>Den tilsvarende kontinuære brøk</returns>
let rec float2cfrac (x : float) : int list =
    let rec recursionFTW (x_i : float) (lst : int list)  : int list =

        let q_i = (floor(System.Math.Round (x_i, 6))) 
        let r_i =  x_i - q_i
        match abs r_i with
        | x when x < 1e-5 -> lst @ [int(q_i)]
        | _ -> recursionFTW (1.0/r_i) (lst @ [int(q_i)])

    recursionFTW x []