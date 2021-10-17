type Position = int
type Board = char list

let create (n : uint ) : Board =
    let lst = ['a' .. 'y']
    lst.[0..((int (n) * int (n))-1)]

let board2Str (b : Board) : string = 
    List.toArray b |> System.String

let validRotation (b : Board) (p : Position) : bool =
    match p with
    | x1 when double p = sqrt (double (b.Length)) -> false
    | x2 when double p = double 2 * sqrt (double (b.Length)) -> false
    | x3 when double p = double 3 * sqrt (double (b.Length)) -> false
    | x4 when double p = double 4 * sqrt (double (b.Length)) -> false
    | x5 when double p > ((double b.Length) - (double (sqrt (double b.Length)))) -> false
    | _ -> true
    
    //if double p <> sqrt (double (b.Length)) then true
    //elif double p <> 2 * sqrt (double (b.Length)) then true
    //elif double p <> 3 * sqrt (double (b.Length)) then true
    //elif double p <> 4 * sqrt (double (b.Length)) then true
    //elif double p < (double b.Length - double (sqrt (b.Length)) then true
    //else false

let rotate (b : Board) (p : Position) : Board =
    let (boardSize : int) = int(sqrt(double b.Length))
    if validRotation (b) (p+1) then
        b.[0..(p-1)] @ (b.[p + boardSize] :: (b.[p] :: (b.[(p+2) .. (p+boardSize-1)] @ (b.[p+boardSize+1] :: (b.[p+1] :: (b.[(p+boardSize+2)..])))))) 
    else b

printfn "%s" (board2Str (create 4u))
printfn "%b" (validRotation (create 4u) (13))
printfn "%b" (validRotation (create 4u) (12))
printfn "%b" (validRotation (create 4u) (6))
printfn "%b" (validRotation (create 5u) (25))
printfn "%b" (validRotation (create 5u) (21))
printfn "4x4 med a: %A" (rotate (create 4u) (0))
printfn "4x4 med d: %A" (rotate (create 4u) (3))
printfn "4x4 med j: %A" (rotate (create 4u) (9))