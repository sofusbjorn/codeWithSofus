
type ('a,'b) result = 
    | Ok of 'a 
    | Err of 'b

let safeDivOption (a : int) (b : int) : int option =
    match b with
    | 0 -> None
    | _ -> Some(a/b)

printfn "%A" (safeDivOption (10) (10))
printfn "%A" (safeDivOption (10) (0))

let safeDivResult (a : int) (b : int) : result<int,string>  =
    if b = 0 then Err "Divide by zero"
    else Ok ((a)/(b))

printfn "%A" (safeDivResult (10) (10))
printfn "%A" (safeDivResult (10) (0))