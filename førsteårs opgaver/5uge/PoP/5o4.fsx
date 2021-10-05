let printLst (lst : 'a list) : unit =
    List.iter (fun i -> printf "%A " i) lst

printLst [1;2;3]
printfn " "
printLst ["hi";"you"] 
printfn " "
printLst [1.111;1.1222]
printfn " "

List.iter (fun i -> printf "%d " i) [1;2;3;4;5]
