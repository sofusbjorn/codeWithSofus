let multiplicity (x : int) (xs : int list) : int =
    let len = List.filter (fun i -> i = x) xs
    len.Length

let x = 100 
let xs = [100;100;100;200;100]
printfn "%A" (multiplicity x xs)
