type 'a tree = 
    |Leaf of 'a 
    |Tree of 'a tree * 'a tree

let rec sum (plant : int tree) : int =
    match plant with
    |Leaf(n) -> n
    |Tree(n,m) -> (sum n) + (sum m)

let (thisPlant : int tree) = Tree(Tree (Leaf 10, Leaf 10),Leaf 10)
printfn "if this doesnt say 30 imma kms foreal foreal: %A" (sum thisPlant)

let rec leafs (plant : 'a tree) : int =
    match plant with
    |Leaf(n) -> 1
    |Tree(n,m) -> (leafs n) + (leafs m)

let (thisPlant2 : int tree) = Tree(Tree(Tree (Leaf 4, Leaf 3),Leaf 2), Leaf 1)
printfn "if this doesnt say 4 imma kms foreal foreal: %A" (leafs thisPlant2)


let rec find (huh : 'a -> bool) (plant :'a tree) : 'a option =
    match plant with
    | 

printfn "%A" (find (fun 4 -> true) (thisPlant2))