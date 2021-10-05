let fac n : int = n * (n-1)
let mutable i = 1
let n = 5
let mutable result = 0

if n < 1 then result <- 1

else while i < n do

     let mutable c = fac n
     result <- c + result
     i <- i + 1
     
printfn "The factorial of %A is %A" n result


