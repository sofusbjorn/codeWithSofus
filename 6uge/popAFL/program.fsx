let rec cfrac2float (lst : int list) : float =
    if (List.contains 0 (lst.Tail))
    then 0.0 
    elif lst.IsEmpty
    then 0.0
    elif lst.Length = 1 
    then float(lst.[0])
    else float(lst.Head) + 1.0/float(cfrac2float(lst.Tail))

let rec cfrac2floatMatch (lst : int list) : float =
    match lst with
    | [] -> 0.0
    | List.contains 0 (lst.Tail) -> 0.0
    | [ _ ] -> float(lst.[0])
    | _ -> float(lst.Head) + 1.0/float(cfrac2floatMatch(lst.Tail))

printfn "%A" (cfrac2floatMatch [1;2;3;4])
printfn "%A" (cfrac2floatMatch [1;2;3])
printfn "%A" (cfrac2floatMatch [1;2])
printfn "%A" (cfrac2floatMatch [100;0;1;2;3])
printfn "%A" (cfrac2floatMatch [])