let rec map (func : 'a -> 'b) (lst :'a list) : 'b list =
    match lst with
    | [] -> []
    | x::xs -> func x :: map func xs