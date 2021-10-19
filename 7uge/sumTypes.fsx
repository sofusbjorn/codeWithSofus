
type ('a,'b) result = 
    | Ok of 'a 
    | Err of 'b

let safeDivOption (a : int) (b : int) : int option =
    match a with
    | b when b = 0 -> None
    | _ -> Some (a/b)

let safeDivOption2 (a : int) (b : int) : int option =
    if b = 0 then None
    else Some (a/b)

printfn "%A" safeDivOption (10) (10)

let safeDivResult (a : int) (b : int) : (int,string) result =
    if b = 0 then Err "Divide by zero"
    else Ok ((a) / (b))


printfn "%A" safeDivResult (10) (10)