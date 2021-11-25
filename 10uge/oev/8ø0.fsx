let rec poly (fLst : float list) (x : float) : float =
    match fLst with
    | [] -> 0.0
    | a::arest ->  a * (x**(float (arest.Length))) + (poly (arest) (x))
printfn "poly: %A" (poly ([1.0;2.0;3.0]) (5.0))
printfn "poly: %A" (poly ([1.0;2.0]) (5.0))

let line (a0 : float) (a1 : float) (x0 : float) : float =
    (poly ([a1;a0]) x0)

printfn "line: %A" (line 1.0 2.0 5.0)

let theLine (x : float) : float =
    (line 1.0 2.0 x)
printfn "theLine: %A" (theLine 5.0)

let lineA0 (a0 : float) : float =
    (line a0 2.0 5.0)
printfn "lineA0: %A" (lineA0 1.0)

let sumsq (fLst : float list) : float =
    fLst 
    |> List.map (fun (x) -> x**2.0) 
    |> List.fold (+) 0.0
printfn "sumsq: %A" (sumsq [3.0;4.0])

let leftPipesumsq (fLst : float list) : float =
    List.fold (+) 0.0 
    <| List.map (fun x -> x**2.0) fLst
printfn "newsumsq: %A" (leftPipesumsq [3.0;4.0])

let llPipesumsq (fLst : float list) : float =
    (List.map (fun (x) -> x**2.0) >> List.fold (+) 0.0) fLst 
printfn "rrsumsq: %A" (llPipesumsq [3.0;4.0])

let rrPipesumsq (fLst : float list) : float =
    (List.fold (+) 0.0 << List.map (fun (x) -> x**2.0)) fLst 
printfn "rrsumsq: %A" (rrPipesumsq [3.0;4.0])