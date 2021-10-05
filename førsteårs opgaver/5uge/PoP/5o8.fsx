let rev (lst : 'a list) : 'a list =
    List.fold (fun acc elem -> elem::acc) [] lst
printfn "%A" (rev [0;1;2]) 
printfn "%A" (rev [2;1;0])
printfn "%A" (rev ["its";"not";"christmas"]) 


