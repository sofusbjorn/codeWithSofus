let rec fac (n : uint) : uint =
    match n with
    | x when x <= 1u -> 1u
    | _ -> n * fac (n - 1u)
printfn "%A" (fac 5u) 

let rec pow2 (n : int) : int =
    match n with
    | x when x <= 0 -> 1
    | _ -> 2 * pow2 (n-1)
printfn "%A" (pow2 10) 

let rec powN (N : int) (n : int) : int =
    match n with
    | x when x <= 0 -> 1
    | _ -> N * powN (N) (n-1)
printfn "%A" (powN 5 2) 

let rec sumRec ( n : uint ) : uint = 
    match n with
    | x when x <= 0u -> 0u
    | _ -> n + sumRec (n-1u)
printfn "%A" (sumRec 100u)

let rec sum (lst : int list) : int =
    match lst with
    | [] -> 0
    | x :: xs -> x + (sum xs)
printfn "%A" (sum [1;2;3;4;5])

let rec length (lst : 'a list) : int =
    match lst with
    | [] -> 0
    | x::xs -> 1 + (length (xs))
printfn "%A" (length [1;2;3;4;5])

let rec lengthAcc (acc : int) (xs : 'a list) : int =
    match xs with
    | [] -> acc
    | _ :: ys -> lengthAcc (acc + 1) ys
printfn "%A" (lengthAcc 15 [1;2;3;4;5])

let rec gcd (t : int) (n : int) : int =
    match n with
    | x when x = 0 -> t
    | _ -> gcd (n) (t % n)
printfn "%A" (gcd 10 15)

let rec lastFloat (lst : float list) : float =
    match lst with
    | [] -> float ("NaN")
    | [x] -> x
    | x::xs -> lastFloat (xs) 
printfn "%A" lastFloat ([1.1;1.2;1.2;1.3])