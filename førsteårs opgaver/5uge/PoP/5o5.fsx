let div2 (lst : int list ) =
    List.map (fun i -> (i/2)) lst

printfn "%A" (div2 [1;10;50;500])
