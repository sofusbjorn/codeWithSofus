printfn "Faculty calculator 3.0"
printfn "Please insert number: "

let input = int (System.Console.ReadLine())

let fac (x : int) : int =

    let mutable i = 1
    let mutable fact = 1
    let n = x

    while i <= n do
        fact <- fact * i
        i <- i + 1
    fact

let cal = fac input
let facoffive = fac 5
printfn "The factorial of %A is %A" input cal


