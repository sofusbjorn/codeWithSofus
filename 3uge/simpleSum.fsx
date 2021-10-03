printfn "Sum calculator 3.0"
printfn "Please insert number: "

//

let input = int (System.Console.ReadLine())

let sum (x : int) : int =

    let n = x
    let sumFunc = (n*(n+1))/2
    sumFunc

let cal = sum input
if input < 1 then printfn "The sum from %A to 1 is 0" input
else
    printfn "The sum from %A to 1 is %A" input cal
