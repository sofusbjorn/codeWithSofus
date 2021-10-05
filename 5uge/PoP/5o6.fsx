let even ( n : int ) : bool =
    if n % 2 = 0 then
        true
    else
        false

printfn "%b" (even 10)

let filterEven (lst : int list) : int list =
    List.filter (fun n -> n%2=0) lst

printfn "%A" (filterEven [100;200;249;24;23;24;14;15])

