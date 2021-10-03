printfn "Sum calculator 3.0"
printfn "Please insert number: "

let input = int (System.Console.ReadLine())

let sum (x : int) : int =

    let mutable i = 1
    let mutable sumFunc = 0
    let n = x
    
    while i <= n do
        sumFunc <- sumFunc + i
        i <- i + 1
    sumFunc

let cal = sum input
if input < 1 then printfn "The sum from %A to 1 is 0" input
else
    printfn "The sum from %A to 1 is %A" input cal
