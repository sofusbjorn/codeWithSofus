printfn "Faculty calculator 3.0"
printfn "Please insert number: "


let mutable i = 1
let mutable fact = 1
let n = int (System.Console.ReadLine())

while i <= n do
       fact <- fact * i
       i <- i + 1
     
printfn "The factorial of %A is %A" n fact


