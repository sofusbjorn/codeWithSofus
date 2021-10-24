type expr = 
    | Const of int
    | Add of expr * expr
    | Mul of expr * expr
    | Sub of expr * expr
    | Div of expr * expr

type ('a,'b) result = 
    | Ok of 'a 
    | Err of 'b

let rec eval (some : expr) : int =
    
    match some with
    | Const(n) -> n
    | Add (n,m) -> (eval (n)) + (eval (m))
    | Sub (n,m) -> (eval (n)) - (eval (m))
    | Mul (n,m) -> (eval (n)) * (eval (m))
    | Div (n,m) -> (eval (n)) / (eval (m))

let (expresser : expr) = (Add(Const 3,Mul(Const 2,Const 4)))
let (expresser2 : expr) = (Sub(Add(Const 3,Mul(Const 2,Const 4)),Const 1))
printfn "If this doesnt say 11 imma kms: %A" (eval expresser)
printfn "If this doesnt say 10 imma kms: %A" (eval expresser2)
