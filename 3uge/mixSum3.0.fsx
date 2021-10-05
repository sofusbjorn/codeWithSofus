printfn " "
printfn "Sum calculator and simpleSum 3.0"
printfn " "

let sumSimple (x : int) : int =

    let n = x
    let sumFunc = (n*(n+1))/2
    sumFunc

(*sumformlen kan skrives ud som s1 =  1 + 2 + 3 +4 + ... n
Hvis man så lægger det udtryk sammen med den omvendte rækkefølge s2 = n + (n - 1) + (n-2)+...1, altså:
(s1 + s2) = (n + 1) + (n + 1) + (n + 1) + ... (n + 1) = n(n+1)
Men da vi tog udgangspunkt i 2 gange udtrykket divideres med 2. Dermed er sumformlen udtrykt ved:
(n(n+1))/2. *)

let sum (x : int) : int =

    let mutable i = 1
    let mutable sumFunc = 0
    let n = x
    
    while i <= n do
        sumFunc <- sumFunc + i
        i <- i + 1
    sumFunc

printfn "%s %4s %7s" "n" "sum n" "sumSimple n"

for j = 1 to 10 do
    if j < 10 then
        printfn "%A %4i %4i" j (sum j) (sumSimple j)
    else
        printfn "%A %3i %4i" j (sum j) (sumSimple j)

