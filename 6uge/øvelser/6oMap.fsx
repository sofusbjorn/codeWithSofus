let rec fold (func : 'a -> 'b -> 'a) (elm : 'a) (lst : 'b list) : 'a =
    match lst with
    | [] -> elm
    | x::xs -> fold func (func elm x) xs