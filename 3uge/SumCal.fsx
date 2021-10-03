printfn "Sum calculator 3.0"
printfn "Please insert number: "

let input = int (System.Console.ReadLine())

let sum (n : int) : int =

    let mutable i = 1
    let mutable sumf = 0
    let n = input

    while i <= n do
        sumf <- sumf + i
        i <- i + 1
    sumf

let cal = sum input
printfn "The sum from %A to 1 is %A" input cal
